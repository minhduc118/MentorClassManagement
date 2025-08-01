﻿#pragma checksum "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6256D7055D2F13B1C7C211138816DA33285D73E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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


namespace MentorClassApp.Views {
    
    
    /// <summary>
    /// ClassManagementView
    /// </summary>
    public partial class ClassManagementView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 190 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ClassesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalClassesText;
        
        #line default
        #line hidden
        
        
        #line 287 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ActiveClassesText;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AddEditOverlay;
        
        #line default
        #line hidden
        
        
        #line 323 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClassNameOverlay;
        
        #line default
        #line hidden
        
        
        #line 326 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescriptionOverlay;
        
        #line default
        #line hidden
        
        
        #line 329 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDateOverlay;
        
        #line default
        #line hidden
        
        
        #line 332 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEndDateOverlay;
        
        #line default
        #line hidden
        
        
        #line 335 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTuitionFeeOverlay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MentorClassApp;component/views/classview/classmanagementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 182 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ClassesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 194 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            this.ClassesDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassesDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TotalClassesText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ActiveClassesText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.AddEditOverlay = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.txtClassNameOverlay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txtDescriptionOverlay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.dpStartDateOverlay = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.dpEndDateOverlay = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 14:
            this.txtTuitionFeeOverlay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            
            #line 339 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveClassOverlay_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 341 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelClassOverlay_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 228 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddLesson_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 235 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddStudent_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 242 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 249 "..\..\..\..\..\Views\ClassView\ClassManagementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

