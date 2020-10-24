using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDF5Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Hdf5Reader hdf5Reader = null;

        private void dataGridViewDropHdf5_DragDrop(object sender, DragEventArgs e)
        {
            string[] fName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //ドロップされたファイルが複数のとき、エラーを返す
            if (fName.Length > 1)
            {
                MessageBox.Show("2個以上のファイルをドロップしないでください");
                return;
            }

            //ドロップされたファイルがHDF5でないとき、エラーを返す
            if (System.IO.Path.GetExtension(fName[0]) != ".hdf5")
            {
                MessageBox.Show("hdf5以外のファイルをドロップしないでください");
                return;
            }
            //hdf5ファイルを読込
            hdf5Reader = new Hdf5Reader(
                fName[0],
                toolStripStatusLabel1,
                statusStrip1,
                dataGridViewDropHdf5);
            hdf5Reader.ReadHdf5();
            labelDropHdf5.Text = "最上位グループ一覧";
        }

        private void dataGridViewDropHdf5_DragEnter(object sender, DragEventArgs e)
        {
            //コントロール内にドラッグされたときに実行
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーする
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewDropHdf5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //「選択グループのみ」がチェックされているとき、クリックした最上位グループ内の一覧を表示
            if (radioButtonSelectedGroupOnly.Checked)
            {
                var groupName = dataGridViewDropHdf5[0, e.RowIndex].Value.ToString();
                hdf5Reader.DisplayLowerGroupsAndData(dataGridViewGroupDetail, "./" + groupName);
            }
        }

        private void dataGridViewGroupDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedName = dataGridViewGroupDetail[0, e.RowIndex].Value.ToString();
            hdf5Reader.MoveToSelectedGroupOrData(dataGridViewGroupDetail, selectedName, radioButtonSelectedGroupOnly.Checked);
        }

        //RadioButtonチェック変更時の処理
        private void radioButtonAllData_CheckedChanged(object sender, EventArgs e)
        {
            //HDF5ファイルが読み込まれているときのみ処理を進める
            if(hdf5Reader != null)
            {
                //「全データ」チェック時、全データを表示
                if (radioButtonAllData.Checked)
                {
                    hdf5Reader.DisplayAllData(dataGridViewGroupDetail);
                }
                //「選択グループのみ」にチェック変更時、選択された最上位フォルダの内容を表示
                else
                {
                    var dataGridDropHdf5Selected = dataGridViewDropHdf5.SelectedCells;
                    if (dataGridDropHdf5Selected.Count == 1)
                    {
                        var groupName = dataGridDropHdf5Selected[0].Value.ToString();
                        hdf5Reader.DisplayLowerGroupsAndData(dataGridViewGroupDetail, "./" + groupName);
                    }
                }
            }
        }
    }
}
