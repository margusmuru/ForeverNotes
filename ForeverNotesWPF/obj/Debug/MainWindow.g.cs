﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ED819ACAE9B2B6F4BDB67EF4C5742102"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ForeverNotes.Service;
using ForeverNotesWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ForeverNotesWPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl MainTabs;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TabHeaderNotes;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewGroup;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewNote;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox NoteGroupListBox;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox NoteListBox;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbNoteHeading;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbNoteTags;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbNoteContent;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TabHeaderToDo;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToDoNewGroup;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ToDoGroupListBox;
        
        #line default
        #line hidden
        
        
        #line 274 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbToDoHeading;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewToDo;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ToDoListBox;
        
        #line default
        #line hidden
        
        
        #line 336 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TabHeaderRSS;
        
        #line default
        #line hidden
        
        
        #line 360 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox NewsListBox;
        
        #line default
        #line hidden
        
        
        #line 387 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RSSLINK;
        
        #line default
        #line hidden
        
        
        #line 398 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoadRSS;
        
        #line default
        #line hidden
        
        
        #line 405 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox contentListBox;
        
        #line default
        #line hidden
        
        
        #line 464 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem File_NewNote;
        
        #line default
        #line hidden
        
        
        #line 510 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ConsoleField;
        
        #line default
        #line hidden
        
        
        #line 513 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Logs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ForeverNotesWPF;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainTabs = ((System.Windows.Controls.TabControl)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.MainTabs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MainTabs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TabHeaderNotes = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.NewGroup = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.NewGroup.Click += new System.Windows.RoutedEventHandler(this.AddGroup_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NewNote = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\MainWindow.xaml"
            this.NewNote.Click += new System.Windows.RoutedEventHandler(this.AddNote_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\MainWindow.xaml"
            this.SearchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\MainWindow.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NoteGroupListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 82 "..\..\MainWindow.xaml"
            this.NoteGroupListBox.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NoteGroupListBox_MouseDown);
            
            #line default
            #line hidden
            
            #line 83 "..\..\MainWindow.xaml"
            this.NoteGroupListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NoteGroupListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NoteListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 13:
            
            #line 139 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NoteContextDelete_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.TbNoteHeading = ((System.Windows.Controls.TextBox)(target));
            
            #line 154 "..\..\MainWindow.xaml"
            this.TbNoteHeading.KeyUp += new System.Windows.Input.KeyEventHandler(this.TbNoteHeading_KeyUp);
            
            #line default
            #line hidden
            return;
            case 15:
            this.TbNoteTags = ((System.Windows.Controls.TextBox)(target));
            
            #line 162 "..\..\MainWindow.xaml"
            this.TbNoteTags.KeyUp += new System.Windows.Input.KeyEventHandler(this.TbNoteTags_KeyUp);
            
            #line default
            #line hidden
            
            #line 162 "..\..\MainWindow.xaml"
            this.TbNoteTags.LostFocus += new System.Windows.RoutedEventHandler(this.TbNoteTags_LostFocus);
            
            #line default
            #line hidden
            return;
            case 16:
            this.TbNoteContent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.TabHeaderToDo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 18:
            this.ToDoNewGroup = ((System.Windows.Controls.Button)(target));
            
            #line 206 "..\..\MainWindow.xaml"
            this.ToDoNewGroup.Click += new System.Windows.RoutedEventHandler(this.AddToDoGroup_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.ToDoGroupListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 216 "..\..\MainWindow.xaml"
            this.ToDoGroupListBox.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ToDoGroupListBox_MouseDown);
            
            #line default
            #line hidden
            
            #line 217 "..\..\MainWindow.xaml"
            this.ToDoGroupListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ToDoGroupListBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 218 "..\..\MainWindow.xaml"
            this.ToDoGroupListBox.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtblk_RightMouseDown);
            
            #line default
            #line hidden
            return;
            case 24:
            this.TbToDoHeading = ((System.Windows.Controls.TextBox)(target));
            
            #line 275 "..\..\MainWindow.xaml"
            this.TbToDoHeading.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbToDoHeading_TextChanged);
            
            #line default
            #line hidden
            
            #line 275 "..\..\MainWindow.xaml"
            this.TbToDoHeading.KeyUp += new System.Windows.Input.KeyEventHandler(this.AddToDoTxtBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 25:
            this.NewToDo = ((System.Windows.Controls.Button)(target));
            
            #line 283 "..\..\MainWindow.xaml"
            this.NewToDo.Click += new System.Windows.RoutedEventHandler(this.AddToDo_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.ToDoListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 30:
            this.TabHeaderRSS = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 31:
            this.NewsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 360 "..\..\MainWindow.xaml"
            this.NewsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NewsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 371 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RssFeedContextDelete_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            this.RSSLINK = ((System.Windows.Controls.TextBox)(target));
            
            #line 390 "..\..\MainWindow.xaml"
            this.RSSLINK.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RSSLINK_TextChanged);
            
            #line default
            #line hidden
            
            #line 391 "..\..\MainWindow.xaml"
            this.RSSLINK.KeyUp += new System.Windows.Input.KeyEventHandler(this.AddRssTxtBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 35:
            this.BtnLoadRSS = ((System.Windows.Controls.Button)(target));
            
            #line 398 "..\..\MainWindow.xaml"
            this.BtnLoadRSS.Click += new System.Windows.RoutedEventHandler(this.BtnLoadRSS_Click);
            
            #line default
            #line hidden
            return;
            case 36:
            this.contentListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 405 "..\..\MainWindow.xaml"
            this.contentListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.contentListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 38:
            this.File_NewNote = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 39:
            
            #line 469 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Sync_Click);
            
            #line default
            #line hidden
            return;
            case 40:
            
            #line 476 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_EmptyTrash_Click);
            
            #line default
            #line hidden
            return;
            case 41:
            
            #line 480 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.View_SwitchToNotes);
            
            #line default
            #line hidden
            return;
            case 42:
            
            #line 485 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.View_SwitchToToDo);
            
            #line default
            #line hidden
            return;
            case 43:
            
            #line 490 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.View_SwitchToRSS);
            
            #line default
            #line hidden
            return;
            case 44:
            
            #line 495 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Checked += new System.Windows.RoutedEventHandler(this.View_CheckShowTabs);
            
            #line default
            #line hidden
            
            #line 495 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.View_UncheckShowTabs);
            
            #line default
            #line hidden
            return;
            case 45:
            this.ConsoleField = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 46:
            this.Logs = ((System.Windows.Controls.Button)(target));
            
            #line 513 "..\..\MainWindow.xaml"
            this.Logs.Click += new System.Windows.RoutedEventHandler(this.OpenLogWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 8:
            
            #line 104 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtblk_RightMouseDown);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 105 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.txtbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 107 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBox_KeyUp);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 110 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NoteGroupListBox_RenameClick);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 111 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NoteGroupListBox_DeleteClick);
            
            #line default
            #line hidden
            break;
            case 20:
            
            #line 236 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txtblk_RightMouseDown);
            
            #line default
            #line hidden
            break;
            case 21:
            
            #line 237 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.ToDoTxtbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 240 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBox_KeyUp);
            
            #line default
            #line hidden
            break;
            case 22:
            
            #line 243 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ToDoGroupListBox_RenameClick);
            
            #line default
            #line hidden
            break;
            case 23:
            
            #line 244 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ToDoGroupListBox_DeleteClick);
            
            #line default
            #line hidden
            break;
            case 27:
            
            #line 306 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToDoCheck_Click);
            
            #line default
            #line hidden
            
            #line 306 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ToDoCheck_Click);
            
            #line default
            #line hidden
            break;
            case 28:
            
            #line 311 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToDoCheck_Click);
            
            #line default
            #line hidden
            
            #line 311 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ToDoCheck_Click);
            
            #line default
            #line hidden
            break;
            case 29:
            
            #line 314 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ToDoListBox_DeleteClick);
            
            #line default
            #line hidden
            break;
            case 32:
            
            #line 363 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.NewsListBoxItem_MouseDown);
            
            #line default
            #line hidden
            break;
            case 37:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 409 "..\..\MainWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.contentListBoxItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
