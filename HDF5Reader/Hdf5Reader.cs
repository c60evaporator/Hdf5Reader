using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HDF5DotNet;
using System.Data;

namespace HDF5Reader
{
    class Hdf5Reader
    {
        //HDF5はこちら参考 http://memo-memo-and-memo.asablo.jp/blog/2013/02/06/6714210
        //定数
        private List<H5T.H5TClass> VALUE_H5TCLASSES = new List<H5T.H5TClass>() { H5T.H5TClass.FLOAT, H5T.H5TClass.INTEGER };//値型として扱うH5TClass
        private List<H5T.H5TClass> STR_H5TClLASSES = new List<H5T.H5TClass>() { H5T.H5TClass.STRING };//文字列型として扱うH5TClass
        private List<H5T.H5TClass> MATRIX_H5TCLASSES = new List<H5T.H5TClass>() { H5T.H5TClass.COMPOUND };//行列型として扱うH5TClass
        //クラス内変数
        private string _hdf5Path;//読み込んだHDF5ファイルのパス
        private ToolStripStatusLabel _toolStripStatusLabel;//処理内容表示用のToolStripStatusLabel
        private StatusStrip _statusStrip;//処理内容表示用のStatusStrip
        private DataGridView _dataGridViewDropHdf5;//HDF5をドラッグ＆ドロップするDataGridView
        private DataGridView _dataGridViewGroupDetail;//グループ内容をを表示するDataGridView
        private DataGridView _dataGridViewData;//データを表示するDataGridView
        private H5FileId _fileId;//読み込んだHDF5ファイルのFileID
        private List<string> _groupList;//グループ一覧
        private List<string> _dataList;//データ一覧
        private string _currentGroup = null;//現在DataGridViewに表示中のグループ名
        private string _currentData = null;//現在DataGridViewに表示中のデータ名

        //コンストラクタ
        public Hdf5Reader(
            string hdf5Path,
            ToolStripStatusLabel toolStripStatusLabel,
            StatusStrip StatusStrip,
            DataGridView dataGridViewDropHdf5,
            DataGridView dataGridViewGroupDetail,
            DataGridView dataGridViewData)
        {
            _hdf5Path = hdf5Path;
            _toolStripStatusLabel = toolStripStatusLabel;
            _statusStrip = StatusStrip;
            _dataGridViewDropHdf5 = dataGridViewDropHdf5;
            _dataGridViewGroupDetail = dataGridViewGroupDetail;
            _dataGridViewData = dataGridViewData;
        }

        //Hdf5を読み込んで、最上位グループをDataGridViewに表示
        public void ReadHdf5()
        {
            //HDF5読込
            H5.Open();
            _fileId = H5F.open(_hdf5Path, H5F.OpenMode.ACC_RDONLY);
            _groupList = new List<string>();
            _dataList = new List<string>();
            GetSubGroupsRepeat(_fileId, ".");
            //最上位グループを表示
            var topGroups = _groupList
                .Where(a => a.Length - a.Replace("/", "").Length == 1)
                .Select(a => a.Split('/')[1])
                .ToList();
            DisplayStrListToDataGrid(topGroups, _dataGridViewDropHdf5, "最上位グループ", false);
            //列幅をDataGridViewの幅に合わせ、列名＆行名表示OFFに
            _dataGridViewDropHdf5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridViewDropHdf5.ColumnHeadersVisible = false;
            _dataGridViewDropHdf5.AllowUserToAddRows = false;
            _dataGridViewDropHdf5.AllowUserToDeleteRows = false;
            _dataGridViewDropHdf5.AllowUserToResizeRows = false;
            _dataGridViewDropHdf5.ReadOnly = true;
        }

        public void CloseHdf5()
        {
            H5F.close(_fileId);
        }

        //階層構造を再帰的に探索
        private void GetSubGroupsRepeat(H5FileId fileId, string groupName)
        {
            //グループ内を探索
            var groupId = H5G.open(fileId, groupName);
            long objectNum = H5G.getNumObjects(groupId);
            //見つけたオブジェクトを走査
            var subGroups = new List<string>();
            for (long i = 0; i < objectNum; i++)
            {
                var objectName = groupName + "/" + H5G.getObjectNameByIndex(groupId, (ulong)i);
                var objectInfo = H5G.getObjectInfo(fileId, objectName, true);
                switch (objectInfo.objectType)
                {
                    case H5GType.GROUP:
                        _groupList.Add(objectName);
                        subGroups.Add(objectName);
                        break;
                    case H5GType.DATASET:
                        _dataList.Add(objectName);
                        break;
                }
            }
            H5G.close(groupId);
            //サブグループが存在するとき、再帰的に走査
            foreach (var subGroup in subGroups)
            {
                GetSubGroupsRepeat(fileId, subGroup);
            }
        }

        //文字列リストをデータテーブルに一覧表示
        private void DisplayStrListToDataGrid(List<string> strList, DataGridView dataGridView, string title, bool addReturn)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(title);
            //「戻る」行を追加
            if (addReturn)
            {
                DataRow row = dataTable.NewRow();
                row[0] = "戻る";
                dataTable.Rows.Add(row);
            }
            //リストを行として追加
            for(int i = 0; i < strList.Count; i++)
            {
                DataRow row = dataTable.NewRow();
                row[0] = strList[i];
                dataTable.Rows.Add(row);
            }
            //データグリッドにデータテーブルを登録
            dataGridView.DataSource = dataTable;
            
            //列幅をDataGridViewの幅に合わせ、列名＆行名表示OFFに
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ReadOnly = true;
        }

        //2次元配列をデータテーブルに一覧表示
        private void DisplayStrSquareArrayToDataGrid(string[,] strArray, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            var colSize = strArray.GetLength(0);
            var rowSize = strArray.GetLength(1);
            //カラムを追加
            for(int j = 0; j < colSize; j++) dataTable.Columns.Add((j + 1).ToString());
            //行を追加
            for (int i = 0; i < rowSize; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < colSize; j++) row[j] = strArray[j, i];
                dataTable.Rows.Add(row);
            }
            //データグリッドにデータテーブルを登録
            dataGridView.DataSource = dataTable;
            //行ヘッダーに行番号を表示
            for (int i = 0; i < rowSize; i++)
            {
                //行ヘッダーに行番号を表示
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dataGridView.RowHeadersWidth = 60;
            //列幅をDataGridViewの幅に合わせ、列名＆行名表示OFFに
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ReadOnly = true;
        }

        //全データをDataGridViewGroupDetailに表示
        public void DisplayAllData()
        {
            DisplayStrListToDataGrid(_dataList, _dataGridViewGroupDetail, "データ一覧", false);
        }

        //グループ内の下位グループ＆データをDataGridViewに表示
        public void DisplayLowerGroupsAndData(string upperGroup)
        {
            _currentGroup = upperGroup;
            string searchStr = upperGroup + "/";//下位検索用文字列
            //下位グループの一覧を取得
            var lowerGroups = _groupList
                .Where(a => a.Length - a.Replace(searchStr, "").Length > 0 && a.Replace(searchStr, "").Length - a.Replace(searchStr, "").Replace("/", "").Length == 0)
                .ToList();
            //下位データの一覧を取得
            var lowerData = _dataList
                .Where(a => a.Length - a.Replace(searchStr, "").Length > 0 && a.Replace(searchStr, "").Length - a.Replace(searchStr, "").Replace("/", "").Length == 0)
                .ToList();
            //下位グループと下位データ一覧をDataGridViewに表示
            DisplayStrListToDataGrid(lowerGroups.Concat(lowerData).ToList(), _dataGridViewGroupDetail, "下位グループとデータ一覧", true);
        }

        //上位グループの内容をDataGridViewに表示
        private void DisplayUpperGroup(string lowerGroup)
        {
            var upperGroupName = GetUpperGroupName(lowerGroup);
            if (upperGroupName != null) DisplayLowerGroupsAndData(upperGroupName);
        }

        //上位グループ名を取得
        private string GetUpperGroupName(string lowerGroup)
        {
            var groupSplit = _currentGroup.Split('/').ToList();
            if (groupSplit.Count >= 2)
            {
                groupSplit.RemoveAt(groupSplit.Count - 1);
                return string.Join("/", groupSplit);
            }
            else return null;
        }

        //DataGridViewGroupDetailをダブルクリックしたときの処理（下位グループ表示 or 上位グループに戻る or データを表示）
        public void MoveToSelectedGroupOrData(string selectedRow, bool selectedGroupOnly, Encoding enc)
        {
            //グループを移動（「選択グループのみ」がチェックされているときのみ）
            if (selectedGroupOnly)
            {
                //グループをクリックしたとき、下位のグループを表示する
                if (_groupList.Contains(selectedRow)) DisplayLowerGroupsAndData(selectedRow);
                //「戻る」をクリックしたとき、上位のグループを表示する
                else if (selectedRow == "戻る") DisplayUpperGroup(selectedRow);
            }
            //データを表示
            if (_dataList.Contains(selectedRow)) DisplayData(selectedRow, enc);
        }

        //DataSetの内容をDataGridViewに表示
        private void DisplayData(string datasetName, Encoding enc)
        {
            //現在表示中のデータ名を更新
            _currentData = datasetName;
            //DataSetの内容を配列に格納
            string[,] displayArray = GetArrayFromDataSet(datasetName, enc);
            //DataGridViewに表示
            DisplayStrSquareArrayToDataGrid(displayArray, _dataGridViewData);
        }

        private string[,] GetArrayFromDataSet(string dataSetName, Encoding enc)
        {
            //hdf5ファイルのDataSetを開く
            var dataSetId = H5D.open(_fileId, dataSetName);
            var dataTypeId = H5D.getType(dataSetId);
            var space = H5D.getSpace(dataSetId);
            var cls = H5T.getClass(dataTypeId);
            //列数、行数のカウント
            int colSize = 1;
            if (MATRIX_H5TCLASSES.Contains(cls)) colSize = H5T.getNMembers(dataTypeId);
            long rowSize = H5S.getSimpleExtentDims(space).First();
            //データ格納
            string[,] displayArray;
            //文字列のとき
            if (STR_H5TClLASSES.Contains(cls))
            {
                displayArray = GetArrayFromStrDataSet(dataSetId, dataTypeId, enc, rowSize);
            }
            //数値のとき
            else
            {
                displayArray = GetArrayFromValueDataSet(dataSetId, dataTypeId, colSize, rowSize);
            }
            H5S.close(space);
            H5T.close(dataTypeId);
            H5D.close(dataSetId);
            return displayArray;
        }

        private string[,] GetArrayFromValueDataSet(H5DataSetId dataSetId, H5DataTypeId dataTypeId, int colSize, long rowSize)
        {
            //データ格納
            double[] doubleArray = new double[colSize * rowSize];//データ格納用配列
            H5Array<double> array = new H5Array<double>(doubleArray);
            H5D.read(dataSetId, dataTypeId, array);

            //colSize × rowSizeの配列に再格納する
            string[,] displayArray = new string[colSize, rowSize];
            for (int j = 0; j < colSize; j++)
            {
                for (int i = 0; i < rowSize; i++)
                {
                    displayArray[j, i] = doubleArray[j + i * colSize].ToString();
                }
            }
            return displayArray;
        }

        private string[,] GetArrayFromStrDataSet(H5DataSetId dataSetId, H5DataTypeId dataTypeId, Encoding enc, long rowSize)
        {
            //いったんByte配列に格納
            int strSize = H5T.getSize(dataTypeId);//文字のバイト数
            byte[] byteArray = new byte[strSize * rowSize];
            H5Array<byte> array = new H5Array<byte>(byteArray);
            H5D.read(dataSetId, dataTypeId, array);
            //stringに変換し配列に格納
            string[,] displayArray = new string[1, rowSize];
            List<byte> byteList = byteArray.ToList();
            for (int i = 0; i < rowSize; i++)
            {
                var strArray = byteList.GetRange(i * strSize, strSize).ToArray();
                displayArray[0, i] = enc.GetString(strArray);
            }
            return displayArray;
        }

        public void OutputData(bool outputAllData, Encoding enc)
        {
            //出力先のディレクトリを指定
            string outDir;//フォルダ名格納用変数
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())//フォルダ指定用ダイアログを開く
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) { return; }//ダイアログの表示
                outDir = dlg.SelectedPath;//フォルダ名を格納
            }

            //Groupに相当するディレクトリを作成
            //全データ出力時
            if (outputAllData)
            {
                foreach (var group in _groupList)
                {
                    System.IO.Directory.CreateDirectory(outDir + "/" + group.Replace("./", ""));
                }
            }
            //表示データのみ出力時
            else if (_currentGroup != null)
            {
                System.IO.Directory.CreateDirectory(outDir + "/" + _currentGroup.Replace("./", ""));
            }

            //DataSetに相当するデータをCSV出力
            //全データ出力時
            if (outputAllData)
            {
                foreach (var dataSet in _dataList)
                {
                    OutputDataSetToCsv(outDir, dataSet, enc);
                }
            }
            //表示データのみ出力時
            else if (_currentData != null)
            {
                OutputDataSetToCsv(outDir, _currentData, enc);
            }
        }

        private void OutputDataSetToCsv(string saveDir, string dataSetName, Encoding enc)
        {
            //DataSetの内容を配列に格納
            string[,] displayArray = GetArrayFromDataSet(dataSetName, enc);
            var colSize = displayArray.GetLength(0);
            var rowSize = displayArray.GetLength(1);

            //DataSet名
            string savePath = saveDir + "/" + dataSetName.Replace("./", "") + ".csv";

            //CSV出力
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(savePath, false, enc))
            {
                //行を走査
                for (int i = 0; i < rowSize; i++)
                {
                    //1行分の文字列を作成
                    List<string> rowString = new List<string>();
                    for (int j = 0; j < colSize; j++)
                    {
                        rowString.Add(displayArray[j, i]);
                    }
                    sw.WriteLine(string.Join(",", rowString));
                }
            }
        }
    }
}
