﻿#pragma checksum "..\..\..\Examiner.GUI\Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "585588AB62F148AEE9789437FA29A2C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Examiner_Pro.Examiner.GUI {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuFile;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuQuestion;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuStudent;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuExams;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuAttempt;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuUsers;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Examiner.GUI\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuSettings;
        
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
            System.Uri resourceLocater = new System.Uri("/Examiner Pro;component/examiner.gui/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Examiner.GUI\Main.xaml"
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
            
            #line 4 "..\..\..\Examiner.GUI\Main.xaml"
            ((Examiner_Pro.Examiner.GUI.Main)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mnuFile = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            
            #line 9 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_FileAbout);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 11 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_FileExit);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mnuQuestion = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            
            #line 14 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_questionNew);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 15 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_questionManage);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mnuStudent = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 9:
            
            #line 18 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_studentEnrol);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 19 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_studentManage);
            
            #line default
            #line hidden
            return;
            case 11:
            this.mnuExams = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 12:
            
            #line 23 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_ExamNew);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 24 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_ExamManage);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 26 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_ExamAssign);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 27 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_ExamDeassign);
            
            #line default
            #line hidden
            return;
            case 16:
            this.mnuAttempt = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 17:
            
            #line 31 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_ExamAttempt);
            
            #line default
            #line hidden
            return;
            case 18:
            this.mnuUsers = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 19:
            
            #line 35 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_userNew);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 36 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_userDelete);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 37 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_userReset);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 38 "..\..\..\Examiner.GUI\Main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_userChangeRole);
            
            #line default
            #line hidden
            return;
            case 23:
            this.mnuSettings = ((System.Windows.Controls.MenuItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

