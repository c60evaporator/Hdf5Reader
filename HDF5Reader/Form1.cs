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
        private Hdf5Reader hdf5Reader;

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
    }
}
