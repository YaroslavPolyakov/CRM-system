﻿#pragma checksum "..\..\..\..\Menu\Clients\Clients.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7747C5ACC7A0E07E143A53601CB51849"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CRM;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace CRM {
    
    
    /// <summary>
    /// Clients
    /// </summary>
    public partial class Clients : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Menu\Clients\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CRM.Clients p_Clients;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Menu\Clients\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid G1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Menu\Clients\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.XmlDataProvider XMLData;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Menu\Clients\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Menu\Clients\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_Clients;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM;component/menu/clients/clients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Menu\Clients\Clients.xaml"
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
            this.p_Clients = ((CRM.Clients)(target));
            return;
            case 2:
            this.G1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.XMLData = ((System.Windows.Data.XmlDataProvider)(target));
            return;
            case 4:
            
            #line 22 "..\..\..\..\Menu\Clients\Clients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Add);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\..\..\Menu\Clients\Clients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Change);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 24 "..\..\..\..\Menu\Clients\Clients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Del);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Menu\Clients\Clients.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Button_Save);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dg_Clients = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

