# Hdf5Reader
## 概要
.hdf5ファイルの階層構造＆データの中身をGUIで確認するためのツール

## コンパイル方法（Visual Studio）
1. [このページ](http://hdf5.net/default.aspx)の真ん中付近にある「HDF5DotNet assembly for .NET Framework 4.0 64-bit」をクリックし、<br>
ダウンロード→解凍したdllファイルをexeファイルと同じ場所に置く

2. 上記dllファイルのうち、HDF5DotNet.dllを参照に追加（Visual Studioの左の「参照」を右クリック→「参照の追加」→「参照」でdllファイルを指定）

3. 実際に動作させるときも、1のdllファイルをコンパイルで生成したexeファイルと同じ場所に置く必要がある（あるいはdllファイルの場所にパスを通す）

## 使い方
### 準備
上記「コンパイル方法」で作成したexeファイルおよびdllファイルを準備、あるいは[こちらのリンク](https://github.com/c60evaporator/Hdf5Reader/releases/tag/v0.0.0)のHDF5Reader.zipをダウンロードして解凍する

※ダウンロード時に以下のメッセージが出た場合も、無視してダウンロードを続けて頂いて大丈夫です
![image](https://user-images.githubusercontent.com/59557625/117273659-4d977b80-ae97-11eb-8475-4f2c3935edf6.png)

### 実際に使用するとき
1. HDF5Reader.exeをダブルクリック

2. .hdf5ファイルを3個並んだ左側のDataGridViewにドラッグ＆ドロップすると、フォルダ構成が表示される。ダブルクリックでグループを移動してファイル内容まで確認できる

### CSV出力
右下の「出力」ボタンを押すと、HDF5のグループをフォルダ構成とし、DataSetをCSV出力できる。
「表示データのみ」をチェックすると表示中のデータのみを、「全データ」をクリックすると、HDF5ファイルに含まれる全てのグループとDataSetが出力される。
また、出力時の文字コードはShift-JISとUTF8が選択できる
