﻿#pragma checksum "..\..\..\..\Wnds\LamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5ECE4668CDF597C3B8EE3E5A5F415B21"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.1
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace Liken.Wnds {
    
    
    /// <summary>
    /// LamePage
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class LamePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox frequency;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bitrate;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox quality;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox channel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox swap;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton cbr;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton abr;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton vbr;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Wnds\LamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton vbrold;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Liken;component/wnds/lamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Wnds\LamePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.frequency = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\..\Wnds\LamePage.xaml"
            this.frequency.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bitrate = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\Wnds\LamePage.xaml"
            this.bitrate.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.quality = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\..\Wnds\LamePage.xaml"
            this.quality.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.channel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\..\Wnds\LamePage.xaml"
            this.channel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.swap = ((System.Windows.Controls.CheckBox)(target));
            
            #line 37 "..\..\..\..\Wnds\LamePage.xaml"
            this.swap.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbr = ((System.Windows.Controls.RadioButton)(target));
            
            #line 40 "..\..\..\..\Wnds\LamePage.xaml"
            this.cbr.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.abr = ((System.Windows.Controls.RadioButton)(target));
            
            #line 41 "..\..\..\..\Wnds\LamePage.xaml"
            this.abr.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.vbr = ((System.Windows.Controls.RadioButton)(target));
            
            #line 42 "..\..\..\..\Wnds\LamePage.xaml"
            this.vbr.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.vbrold = ((System.Windows.Controls.RadioButton)(target));
            
            #line 43 "..\..\..\..\Wnds\LamePage.xaml"
            this.vbrold.Checked += new System.Windows.RoutedEventHandler(this.Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

