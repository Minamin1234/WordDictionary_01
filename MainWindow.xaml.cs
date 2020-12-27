using System;
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

namespace WordDictionary_01
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables
        public string Default_TextBox_Word_Text = "Apple,Notebook, etc.";
        public bool IsFocused_TextBox_Word = false;
        public Brush Default_Button_Color = new SolidColorBrush(Color.FromRgb(221, 221, 221));
        public Brush Selected_Button_Color = new SolidColorBrush(Color.FromRgb(128, 128, 128));
        public enum SearchMode
        {
            Word,
            Idiom,
        }
        public SearchMode CurrentMode = SearchMode.Word;
        

        //InitialFunction
        /// <summary>
        /// 初期のセットアップを実行します。
        /// </summary>
        public void SetUp()
        {
            TextBox_Word.Text = Default_TextBox_Word_Text;
        }

        //Functions
        /// <summary>
        /// 現在の検索モードを設定します。
        /// </summary>
        /// <param name="SelectedMode"></param>
        public void ApplyCurrentMode(SearchMode SelectedMode = SearchMode.Word)
        {
            switch (SelectedMode)
            {
                case SearchMode.Word:
                    Button_Word.Background = Selected_Button_Color;
                    Button_Idiom.Background = Default_Button_Color;
                    break;

                case SearchMode.Idiom:
                    Button_Idiom.Background = Selected_Button_Color;
                    Button_Word.Background = Default_Button_Color;
                    break;

                default:
                    break;
            }
            
        }

        /// <summary>
        /// テキストボックスの現在のフォーカスの状態を設定します。
        /// </summary>
        /// <param name="IsFocussed"></param>
        public void ApplyCurrentFocus(bool IsFocussed = false)
        {
            if(IsFocussed == true)
            {
                if(TextBox_Word.Text == Default_TextBox_Word_Text)
                {
                    TextBox_Word.Text = "";
                }
            }
            else
            {
                if(TextBox_Word.Text == "")
                {
                    TextBox_Word.Text = Default_TextBox_Word_Text;
                }
            }
        }

        public void AddToListBox(string Text = "")
        {
            if(Text != "")
            {
                ListBox_Words.Items.Add(Text);
            }
            else
            {

            }
        }

        //EventFunctions

        public MainWindow()
        {
            InitializeComponent();
            SetUp();
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            //AddToListBox("A");
        }


        private void TextBox_Word_GetForcus(object sender, RoutedEventArgs e)
        {
            IsFocused_TextBox_Word = true;
            ApplyCurrentFocus(IsFocused_TextBox_Word);
        }

        private void TextBox_Word_LostFocus(object sender, RoutedEventArgs e)
        {
            IsFocused_TextBox_Word = false;
            ApplyCurrentFocus(IsFocused_TextBox_Word);
        }


        private void Button_Mode_Clicked(object sender, RoutedEventArgs e)
        {
            Button CurrentButton = (Button)sender;
            switch (CurrentButton.Content)
            {
                case "Word":
                    CurrentMode = SearchMode.Word;
                    break;

                case "Idiom":
                    CurrentMode = SearchMode.Idiom;
                    break;

                default:
                    Console.WriteLine("WARNING: This mode is not surpported.");
                    break;
            }
            ApplyCurrentMode(CurrentMode);

        }
    }
}
