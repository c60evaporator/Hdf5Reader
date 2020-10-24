﻿using System;
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
        //クラス内変数
        private string _hdf5Path;//検索対象フォルダを指定するためのCSVファイル
        private ToolStripStatusLabel _toolStripStatusLabel;//処理内容表示用のToolStripStatusLabel
        private StatusStrip _statusStrip;//処理内容表示用のStatusStrip
        private DataGridView _dataGridViewDropHdf5;//HDF5をドラッグ＆ドロップするDataGridView
        private List<string> _groupList;//グループ一覧
        private List<string> _dataList;//データ一覧
        private string _currentGroup;//現在の

        //コンストラクタ
        public Hdf5Reader(
            string hdf5Path,
            ToolStripStatusLabel toolStripStatusLabel,
            StatusStrip StatusStrip,
            DataGridView dataGridViewDropHdf5)
        {
            _hdf5Path = hdf5Path;
            _toolStripStatusLabel = toolStripStatusLabel;
            _statusStrip = StatusStrip;
            _dataGridViewDropHdf5 = dataGridViewDropHdf5;
        }

        //Hdf5を読み込んで、最上位グループをDataGridViewに表示
        public void ReadHdf5()
        {
            //HDF5読込
            H5.Open();
            var fileId = H5F.open(_hdf5Path, H5F.OpenMode.ACC_RDONLY);
            _groupList = new List<string>();
            _dataList = new List<string>();
            GetSubGroupsRepeat(fileId, ".");
            //最上位グループを表示
            var topGroups = _groupList
                .Where(a => a.Length - a.Replace("/", "").Length == 1)
                .Select(a => a.Split('/')[1])
                .ToList();
            DisplayStrListToDataGrid(topGroups, _dataGridViewDropHdf5, "最上位グループ", false);
            //列幅をDataGridViewの幅に合わせ、列名表示OFFに
            _dataGridViewDropHdf5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridViewDropHdf5.ColumnHeadersVisible = false;
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
            dataGridView.RowHeadersVisible = false;
        }
    }
}