﻿#pragma checksum "..\..\..\..\Wnds\DemoConvWnd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDE1A9F7ABD912E9CF6381539C2CB7D3"
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
    /// DemoConvWnd
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class DemoConvWnd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Wnds\DemoConvWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider source;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Wnds\DemoConvWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lC1;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Wnds\DemoConvWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lC2;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Wnds\DemoConvWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lC3;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Wnds\DemoConvWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress;
        
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
            System.Uri resourceLocater = new System.Uri("/Liken;component/wnds/democonvwnd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Wnds\DemoConvWnd.xaml"
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
            
            #line 4 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((Liken.Wnds.DemoConvWnd)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.source = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            
            #line 27 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.TestBtn);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StopBtn);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 43 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeCodec);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 44 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeCodec);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 45 "..\..\..\..\Wnds\DemoConvWnd.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeCodec);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lC1 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lC2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lC3 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.progress = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

