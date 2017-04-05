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
using ForeverNotesWPF.ViewModels;
using System.Text.RegularExpressions;


namespace ForeverNotesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainVM _mainVm;
        public MainVM MainVM
        {
            get { return _mainVm; }
            set { _mainVm = value; }
        }



        private NotesTabVM _notesTabVm;
        public NotesTabVM NotesTabVm
        {
            get { return _notesTabVm; ; }
            set
            {
                if (_notesTabVm != value)
                {
                    _notesTabVm = value;
                }
            }
        }

        private ToDoTabVM _toDoTabVm;
        public ToDoTabVM ToDoTabVm
        {
            get { return _toDoTabVm; }
            set { _toDoTabVm = value; }
        }

        private RSSTabVM _rssTabVm;
        public RSSTabVM RSSTabVm
        {
            get { return _rssTabVm; }
            set { _rssTabVm = value; }
        }



        private object _clickedListObject;


        public MainWindow()
        {
            InitializeComponent();
            _mainVm = new MainVM();
            _notesTabVm = new NotesTabVM();
            _toDoTabVm = new ToDoTabVM();
            _rssTabVm = new RSSTabVM();

            this.DataContext = _mainVm;

            _mainVm.Children.Add(_notesTabVm);
            _mainVm.Children.Add(_toDoTabVm);
            _mainVm.Children.Add(_rssTabVm);

            /*
            try
            {
                NoteGroupListBox.SelectedItem = NoteGroupListBox.Items.GetItemAt(0);
            }
            catch (Exception ex) { }
            */
        }

        /**
         * General items
         */

        private void View_SwitchToNotes(object sender, RoutedEventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void View_SwitchToToDo(object sender, RoutedEventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void View_SwitchToRSS(object sender, RoutedEventArgs e)
        {
            MainTabs.SelectedIndex = 2;
        }

        private void View_CheckShowTabs(object sender, RoutedEventArgs e)
        {
            TabHeaderNotes.Height = 20;
            TabHeaderToDo.Height = 20;
            TabHeaderRSS.Height = 20;

        }

        private void View_UncheckShowTabs(object sender, RoutedEventArgs e)
        {
            TabHeaderNotes.Height = 0;
            TabHeaderToDo.Height = 0;
            TabHeaderRSS.Height = 0;
        }

        private void MainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /**
         * Edit Menu
         */


        private void Edit_EmptyTrash_Click(object sender, RoutedEventArgs e)
        {
            _notesTabVm.EmptyTrash(NoteGroupListBox.SelectedIndex == 1);
        }

        /**
         * Other
         */

        protected void txtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];
            tb.Text = ((TextBox)sender).Text;
            tb.Visibility = Visibility.Visible;
            ((TextBox)sender).Visibility = Visibility.Collapsed;
        }

        private void NoteGroupListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NoteGroupListBox.UnselectAll();
        }

        private void NoteGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Selected Group Index: " + NoteGroupListBox.SelectedIndex);
            if (NoteGroupListBox.SelectedIndex == -1)
            {
                NewNote.IsEnabled = false;
                File_NewNote.IsEnabled = false;
                return;
            }
            else
            {
                if (NoteGroupListBox.SelectedIndex > 2)
                {
                    NewNote.IsEnabled = true;
                    File_NewNote.IsEnabled = true;
                }
                else
                {
                    NewNote.IsEnabled = false;
                    File_NewNote.IsEnabled = false;
                }
                _notesTabVm.SetNotesList(NoteGroupListBox.SelectedItem);
            }
        }

        private void NoteGroupListBox_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (NoteGroupListBox.SelectedIndex == -1)
            {
                return;
            }
            if (NoteGroupListBox.SelectedIndex > 2)
            {
                _notesTabVm.RemoveNoteGroup(NoteGroupListBox.SelectedIndex);
                NoteGroupListBox.SelectedIndex = 0;
                NoteGroupListBox_SelectionChanged(null, null);
            }
        }

        private void NoteGroupListBox_RenameClick(object sender, RoutedEventArgs e)
        {
            if (NoteGroupListBox.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                if (!((TextBlock)_clickedListObject).Text.Equals("All Notes"))
                {
                    TextBox txt = (TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1];
                    txt.Visibility = Visibility.Visible;
                    ((TextBlock)sender).Visibility = Visibility.Collapsed;
                }

            }
            catch (Exception ex) { }
        }

        private void txtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                try
                {
                    TextBlock tb = (TextBlock)_clickedListObject;
                    tb.Text = ((TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1]).Text;
                    tb.Visibility = Visibility.Visible;
                    ((TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1]).Visibility = Visibility.Collapsed;

                    if (MainTabs.SelectedIndex == 0)
                        _notesTabVm.RenameNoteGroup(NoteGroupListBox.SelectedIndex, tb.Text);
                    if (MainTabs.SelectedIndex == 1)
                        _toDoTabVm.RenameToDoGroup(ToDoGroupListBox.SelectedIndex, tb.Text);
                    
                }
                catch (Exception ex) { }
            }
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                TextBlock tb = (TextBlock)_clickedListObject;
                tb.Visibility = Visibility.Visible;
                ((TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1]).Visibility = Visibility.Collapsed;
                ((TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1]).Text = tb.Text;
            }
        }

        private void TbNoteHeading_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                TbNoteContent.Focus();
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            _notesTabVm.AddNoteGroup("");
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            _notesTabVm.AddNote(NoteGroupListBox.SelectedIndex);
            try
            {
                NoteListBox.SelectedItem = NoteListBox.Items.GetItemAt(0);
            }
            catch (Exception ex) { }
        }
        
        private void MenuItem_Sync_Click(object sender, RoutedEventArgs e)
        {
            _notesTabVm.Sync();
            _toDoTabVm.Sync();
            _rssTabVm.Sync();
        }

        private void OpenLogWindow_Click(object sender, RoutedEventArgs e)
        {
            LogWindow _logWindow = new LogWindow();
            _logWindow.Show();
        }

        private void NoteContextDelete_Click(object sender, RoutedEventArgs e)
        {
            _notesTabVm.RemoveNote(NoteListBox.SelectedIndex, NoteGroupListBox.SelectedIndex);
        }


        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbNoteTags_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TbNoteTags_LostFocus(object sender, RoutedEventArgs e)
        {

        }




        /*
         * ToDo stuff
         */
        private void AddToDo_Click(object sender, RoutedEventArgs e)
        {
            if(ToDoGroupListBox.HasItems && ToDoGroupListBox.SelectedIndex >= 0 && !TbToDoHeading.Text.Equals(""))
            {
                _toDoTabVm.AddToDo(ToDoGroupListBox.SelectedIndex, TbToDoHeading.Text);
                TbToDoHeading.Text = "";
                TbToDoHeading.Focus();
            }
            
        }

        private void AddToDoTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AddToDo_Click(null, null);
        }

        private void AddToDoGroup_Click(object sender, RoutedEventArgs e)
        {
            _toDoTabVm.AddToDoGroup();
            ToDoGroupListBox.SelectedItem = ToDoGroupListBox.Items.GetItemAt(ToDoGroupListBox.Items.Count - 1);
        }

        private void TbToDoHeading_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToDoGroupListBox_RenameClick(object sender, RoutedEventArgs e)
        {
            if (ToDoGroupListBox.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                    TextBox txt = (TextBox)((Grid)((TextBlock)_clickedListObject).Parent).Children[1];
                    txt.Visibility = Visibility.Visible;
                    ((TextBlock)sender).Visibility = Visibility.Collapsed;


            }
            catch (Exception ex) { }
        }

        private void ToDoGroupListBox_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (ToDoGroupListBox.SelectedIndex >= 0)
            {
                _toDoTabVm.RemoveToDoGroup(ToDoGroupListBox.SelectedIndex);
                ToDoGroupListBox.SelectedIndex = 0;
                ToDoGroupListBox_SelectionChanged(null, null);
                if (ToDoGroupListBox.HasItems)
                {
                    ToDoGroupListBox.SelectedItem = ToDoGroupListBox.Items.GetItemAt(0);
                }
            }
        }
        
        private void ToDoListBox_DeleteClick(object sender, RoutedEventArgs e)
        {
            _toDoTabVm.RemoveToDo(ToDoListBox.SelectedIndex, ToDoGroupListBox.SelectedIndex);
        }

        private void ToDoGroupListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ToDoGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToDoGroupListBox.SelectedIndex < 0)
            {
                NewToDo.IsEnabled = false;
            }
            else
            {
                NewToDo.IsEnabled = true;
                _toDoTabVm.SetToDos(ToDoGroupListBox.SelectedIndex);
            }
        }

        private void ToDoTxtbox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ToDoCheck_Click(object sender, RoutedEventArgs e)
        {
            ToDoGroupListBox_SelectionChanged(null, null);
        }

        /*
         * RSS stuff
         */

        private void BtnLoadRSS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RSSLINK.Text != String.Empty)
                {
                    _rssTabVm.AddNewFeed(RSSLINK.Text);
                    RSSLINK.Text = "";
                }
            }
            catch (Exception)
            {
                // Console.WriteLine(e.Message);
            }
        }

        protected void NewsListBoxItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _clickedListObject = sender;

        }

        private void RSSLINK_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NewsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NewsListBox.SelectedIndex >= 0)
                _rssTabVm.SetCurrentFeed(NewsListBox.SelectedIndex);
        }

 

        //dunno mis seda kasutab...
        protected void txtblk_RightMouseDown(object sender, MouseButtonEventArgs e)
        {
            _clickedListObject = sender;
        }
        

        protected void contentListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (contentListBox.SelectedIndex >= 0)
            {
                try
                {
                        //opens selected news link in user's computer
                        System.Diagnostics.Process.Start(_rssTabVm.SelectedNews.ElementAt(contentListBox.SelectedIndex).Link);

                }
                catch (ArgumentOutOfRangeException)
                {
                    //Console.WriteLine("");
                }
            }

        }


        private void contentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }

        private void RssFeedContextDelete_Click(object sender, RoutedEventArgs e)
        {
            _rssTabVm.RemoveFeed(NewsListBox.SelectedIndex);
        }
        

        private void AddRssTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnLoadRSS_Click(null, null);
        }

        
    }
}
