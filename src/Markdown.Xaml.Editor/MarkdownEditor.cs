using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Markdown.Xaml.Editor {
    [TemplatePart(Name = EditIconPartName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = FlowDocumentScrollViewerPartName, Type = typeof(FlowDocumentScrollViewer))]
    public class MarkdownEditor : Control {
        public event EventHandler<LinkClickedEventArgs> LinkClicked;

        private const string EditIconPartName = "PART_EditIcon";
        private const string FlowDocumentScrollViewerPartName = "PART_FlowDocumentScrollViewer";

        private readonly Markdown markdown;

        private FlowDocumentScrollViewer documentViewer;
        private FrameworkElement editIcon;

        static MarkdownEditor() {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(MarkdownEditor), new FrameworkPropertyMetadata(typeof(MarkdownEditor)));
        }

        public MarkdownEditor()
            : base() {

            markdown = new Markdown();

            CommandBindings.Add(new CommandBinding(NavigationCommands.GoToPage, OnLinkClicked));
        }

        private void OnLinkClicked(object sender, ExecutedRoutedEventArgs e) {
            LinkClicked?.Invoke(this, new LinkClickedEventArgs((string)e.Parameter));
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            this.editIcon = (FrameworkElement)Template.FindName(EditIconPartName, this);
            this.editIcon.MouseLeftButtonUp += EditIcon_MouseLeftButtonUp;

            this.documentViewer = (FlowDocumentScrollViewer)Template.FindName(FlowDocumentScrollViewerPartName, this);
            ConfigureDocumentViewer(documentViewer);
        }

        private void ConfigureDocumentViewer(FlowDocumentScrollViewer documentViewer) {
            if (documentViewer == null) {
                throw new ArgumentNullException(nameof(documentViewer));
            }

            Binding binding = new Binding("Text") {
                Converter = new TextToFlowDocumentConverter() {
                    Markdown = markdown,
                },
            };

            documentViewer.SetBinding(FlowDocumentScrollViewer.DocumentProperty, binding);
        }

        private void EditIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            ToggleEditMode();
        }

        public void ToggleEditMode() {
            IsInEditMode = !IsInEditMode;
        }

        #region DocumentStyle property

        public static readonly DependencyProperty DocumentStyleProperty =
             DependencyProperty.Register(nameof(DocumentStyle), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(DocumentStyle_Changed));

        private static void DocumentStyle_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.DocumentStyle = (Style)e.NewValue;
        }

        public Style DocumentStyle {
            get { return (Style)GetValue(DocumentStyleProperty); }
            set { SetValue(DocumentStyleProperty, value); }
        }
        #endregion

        #region Heading1Style Property

        public static readonly DependencyProperty Heading1StyleProperty =
             DependencyProperty.Register(nameof(Heading1Style), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(Heading1Style_Changed));

        private static void Heading1Style_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.Heading1Style = (Style)e.NewValue;
        }

        public Style Heading1Style {
            get { return (Style)GetValue(Heading1StyleProperty); }
            set { SetValue(Heading1StyleProperty, value); }
        }

        #endregion

        #region Heading2Style Property

        public static readonly DependencyProperty Heading2StyleProperty =
             DependencyProperty.Register(nameof(Heading2Style), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(Heading2Style_Changed));

        private static void Heading2Style_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.Heading2Style = (Style)e.NewValue;
        }

        public Style Heading2Style {
            get { return (Style)GetValue(Heading2StyleProperty); }
            set { SetValue(Heading2StyleProperty, value); }
        }

        #endregion

        #region Heading3Style Property

        public static readonly DependencyProperty Heading3StyleProperty =
             DependencyProperty.Register(nameof(Heading3Style), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(Heading3Style_Changed));

        private static void Heading3Style_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.Heading3Style = (Style)e.NewValue;
        }

        public Style Heading3Style {
            get { return (Style)GetValue(Heading3StyleProperty); }
            set { SetValue(Heading3StyleProperty, value); }
        }

        #endregion

        #region Heading4Style Property

        public static readonly DependencyProperty Heading4StyleProperty =
             DependencyProperty.Register(nameof(Heading4Style), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(Heading4Style_Changed));

        private static void Heading4Style_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.Heading4Style = (Style)e.NewValue;
        }

        public Style Heading4Style {
            get { return (Style)GetValue(Heading4StyleProperty); }
            set { SetValue(Heading4StyleProperty, value); }
        }

        #endregion

        #region LinkStyle Property

        public static readonly DependencyProperty LinkStyleProperty =
             DependencyProperty.Register(nameof(LinkStyle), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(LinkStyle_Changed));

        private static void LinkStyle_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.LinkStyle = (Style)e.NewValue;
        }

        public Style LinkStyle {
            get { return (Style)GetValue(LinkStyleProperty); }
            set { SetValue(LinkStyleProperty, value); }
        }

        #endregion

        #region ImageStyle Property

        public static readonly DependencyProperty ImageStyleProperty =
             DependencyProperty.Register(nameof(ImageStyle), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(ImageStyle_Changed));

        private static void ImageStyle_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.ImageStyle = (Style)e.NewValue;
        }

        public Style ImageStyle {
            get { return (Style)GetValue(ImageStyleProperty); }
            set { SetValue(ImageStyleProperty, value); }
        }

        #endregion

        #region SeparatorStyle Property

        public static readonly DependencyProperty SeparatorStyleProperty =
             DependencyProperty.Register(nameof(SeparatorStyle), typeof(Style),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(SeparatorStyle_Changed));

        private static void SeparatorStyle_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.SeparatorStyle = (Style)e.NewValue;
        }

        public Style SeparatorStyle {
            get { return (Style)GetValue(SeparatorStyleProperty); }
            set { SetValue(SeparatorStyleProperty, value); }
        }

        #endregion

        #region AssetPathRoot Property

        public static readonly DependencyProperty AssetPathRootProperty =
             DependencyProperty.Register(nameof(AssetPathRoot), typeof(String),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(Environment.CurrentDirectory, AssetPathRoot_Changed));
 
        private static void AssetPathRoot_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            MarkdownEditor source = sender as MarkdownEditor;
            if (source == null) {
                return;
            }

            source.markdown.AssetPathRoot = (string)e.NewValue;
        }

        public string AssetPathRoot {
            get { return (string)GetValue(AssetPathRootProperty); }
            set { SetValue(AssetPathRootProperty, value); }
        }

        #endregion

        #region Text property

        public static readonly DependencyProperty TextProperty =
             DependencyProperty.Register(nameof(Text), typeof(String),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(string.Empty));

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region IsInEditMode property

        public static readonly DependencyProperty IsInEditModeProperty =
             DependencyProperty.Register(nameof(IsInEditMode), typeof(Boolean),
             typeof(MarkdownEditor), new FrameworkPropertyMetadata(false));

        public bool IsInEditMode {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        #endregion
    }
}
