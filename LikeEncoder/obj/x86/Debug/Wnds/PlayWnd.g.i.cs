﻿#pragma checksum "..\..\..\..\Wnds\PlayWnd.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1348BB635C2710D1E0C15CB3F3343F5720C77C13"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
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


namespace LikeEncoder.Wnds {
    
    
    /// <summary>
    /// PlayWnd
    /// </summary>
    public partial class PlayWnd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider pos;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lpos;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider vol;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lvol;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStop;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Wnds\PlayWnd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVst;
        
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
            System.Uri resourceLocater = new System.Uri("/LikeEncoder;component/wnds/playwnd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Wnds\PlayWnd.xaml"
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
            
            #line 4 "..\..\..\..\Wnds\PlayWnd.xaml"
            ((LikeEncoder.Wnds.PlayWnd)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pos = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            this.lpos = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.vol = ((System.Windows.Controls.Slider)(target));
            
            #line 22 "..\..\..\..\Wnds\PlayWnd.xaml"
            this.vol.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.vol_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lvol = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Wnds\PlayWnd.xaml"
            this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnStop = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Wnds\PlayWnd.xaml"
            this.btnStop.Click += new System.Windows.RoutedEventHandler(this.btnStop_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnVst = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Wnds\PlayWnd.xaml"
            this.btnVst.Click += new System.Windows.RoutedEventHandler(this.btnVst_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
