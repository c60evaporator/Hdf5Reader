# Hdf5Reader
## 概要
.hdf5ファイルの階層構造＆データの中身をGUIで確認するためのツール

## コンパイル方法（Visual Studio）
1. [このページ](http://hdf5.net/default.aspx)の真ん中付近にある「HDF5DotNet assembly for .NET Framework 4.0 64-bit」をクリックし、<br>
ダウンロード→解凍したdllファイルをexeファイルと同じ場所に置く

2. 上記dllファイルのうち、HDF5DotNet.dllを参照に追加（Visual Studioの左の「参照」を右クリック→「参照の追加」→「参照」でdllファイルを指定）

## 使い方
### 準備
上記「コンパイル方法」の1.の操作と同様、dllファイルをexeファイルと同じ場所に置く必要がある（あるいはdllファイルの場所にパスを通す）

### 実際に使用するとき
.hdf5ファイルを3個並んだ左側のDataGridViewにドラッグ＆ドロップすると、フォルダ構成が表示される。ダブルクリックでグループを移動してファイル内容まで確認できる
