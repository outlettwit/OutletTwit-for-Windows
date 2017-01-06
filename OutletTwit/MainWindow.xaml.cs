﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OutletTwit.Core.UI.Forms
{
  /// <summary>
  /// MainWindow.xaml の相互作用ロジック
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// ウィンドウの状態（最大化、最小化）が変わったときに発生するイベントです。
    /// WindowChromeのフレーム描画に伴うウィンドウサイズのずれを修正します。
    /// </summary>
    /// <param name="sender">イベントの呼び出し元</param>
    /// <param name="e">イベント引数</param>
    private void OnWindowStateChanged(object sender, EventArgs e)
    {
      // 現在のウィンドウ状態により分岐
      switch (WindowState)
      {
        case WindowState.Maximized: // 最大化されたとき
          LayoutRoot.Margin = new Thickness(7); // レイアウトルート（Grid）に7pxの余白を与える
          MaximizeButtonMaximizeImage.Visibility = Visibility.Collapsed; // 最大化ボタンを非表示にする
          MaximizeButtonDefaultImage.Visibility = Visibility.Visible; // 通常化ボタンを表示する
          break;

        default: // それ以外のとき
          LayoutRoot.Margin = new Thickness(0); // 余白を0pxにする
          MaximizeButtonMaximizeImage.Visibility = Visibility.Visible; // 最大化ボタンを表示する
          MaximizeButtonDefaultImage.Visibility = Visibility.Collapsed; // 通常化ボタンを非表示にする
          break;
      }
    }

    /// <summary>
    /// 最小化ボタンがクリックされたときのイベントを処理します。
    /// ウィンドウを最小化状態に変更します。
    /// </summary>
    /// <param name="sender">イベントの呼び出し元</param>
    /// <param name="e">イベント引数</param>
    private void OnMinimizeButtonClicked(object sender, RoutedEventArgs e)
    {
      // ウィンドウを最小化状態にする
      WindowState = WindowState.Minimized;
    }

    /// <summary>
    /// 最大化/元に戻すボタンがクリックされたときのイベントを処理します。
    /// ウィンドウを最大化状態または通常の状態に変更します。
    /// </summary>
    /// <param name="sender">イベントの呼び出し元</param>
    /// <param name="e">イベント引数</param>
    private void OnMaximizeButtonClicked(object sender, RoutedEventArgs e)
    {
      // 現在のウィンドウ状態により分岐
      switch (WindowState)
      {
        case WindowState.Maximized: // 最大化状態のとき
          WindowState = WindowState.Normal; // 通常状態に戻す
          break;

        default: // それ以外のとき
          WindowState = WindowState.Maximized; // 最大化状態にする
          break;
      }
    }

    /// <summary>
    /// 閉じるボタンがクリックされたときのイベントを処理します。
    /// ウィンドウを閉じます。
    /// </summary>
    /// <param name="sender">イベントの呼び出し元</param>
    /// <param name="e">イベント引数</param>
    private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
    {
      // 何らかの終了処理が必要な場合は、ここに追加してください。

      // ウィンドウを閉じる
      Close();
    }

    ///<summary>
    ///タイトル部分のアイコンがクリックされた時のイベントを処理します。
    ///マウスの位置を取得し、PointToScreenによって相対座標をざったい座標に変換します(多分)。
    ///システムメニューを表示します。
    ///</summary>
    private void OnTitleIconClicked(object sender, MouseEventArgs e)
    {
      Point mousePoint = e.GetPosition(this);
      Point mousePointFix = PointToScreen(mousePoint);
      SystemCommands.ShowSystemMenu(this, new Point(mousePointFix.X, mousePointFix.Y));
    }
  }
}
