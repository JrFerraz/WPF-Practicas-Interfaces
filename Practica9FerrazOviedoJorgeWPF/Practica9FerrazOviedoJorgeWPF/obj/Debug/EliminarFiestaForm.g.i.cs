﻿#pragma checksum "..\..\EliminarFiestaForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17C1012DEDFBDDEB64532F9B9E02C493398932637ACF6DFAE6A48DAA3796CB89"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica9FerrazOviedoJorgeWPF;
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


namespace Practica9FerrazOviedoJorgeWPF {
    
    
    /// <summary>
    /// EliminarFiestaForm
    /// </summary>
    public partial class EliminarFiestaForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\EliminarFiestaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Practica9FerrazOviedoJorgeWPF.EliminarFiestaForm EliminarFiestaForm1;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\EliminarFiestaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FiestaLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EliminarFiestaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FiestasComboBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EliminarFiestaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EliminarButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Practica9FerrazOviedoJorgeWPF;component/eliminarfiestaform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EliminarFiestaForm.xaml"
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
            this.EliminarFiestaForm1 = ((Practica9FerrazOviedoJorgeWPF.EliminarFiestaForm)(target));
            
            #line 8 "..\..\EliminarFiestaForm.xaml"
            this.EliminarFiestaForm1.Closed += new System.EventHandler(this.EliminarFiestaForm1_Closed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\EliminarFiestaForm.xaml"
            this.EliminarFiestaForm1.Activated += new System.EventHandler(this.EliminarFiestaForm1_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FiestaLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.FiestasComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.EliminarButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\EliminarFiestaForm.xaml"
            this.EliminarButton.Click += new System.Windows.RoutedEventHandler(this.EliminarButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
