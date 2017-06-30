using Markdown.Xaml.Editor;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace MarkdownEditorDemo {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = this;

            Text = File.ReadAllText("MainWindow.md");
        }

        #region Text property

        public static readonly DependencyProperty TextProperty =
             DependencyProperty.Register(nameof(Text), typeof(String),
             typeof(MainWindow), new FrameworkPropertyMetadata());

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        private void MarkdownEditor_LinkClicked(object sender, LinkClickedEventArgs e) {
            Process.Start(e.Uri);
        }
    }
}
