﻿#pragma checksum "..\..\Validations.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "304F46ACE6E9780E55BE53997BE4A2FEFDD2427A"
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
using System.Windows.Forms.Integration;
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
using WpfPractise;


namespace WpfPractise {
    
    
    /// <summary>
    /// Validations
    /// </summary>
    public partial class Validations : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\Validations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_EmployeeData;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Validations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_Name;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfPractise;component/validations.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Validations.xaml"
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
            this.grid_EmployeeData = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 51 "..\..\Validations.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Confirm_CanExecute);
            
            #line default
            #line hidden
            
            #line 51 "..\..\Validations.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Confirm_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBox_Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\Validations.xaml"
            this.textBox_Name.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 65 "..\..\Validations.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

