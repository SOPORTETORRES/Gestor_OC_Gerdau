﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestor_OC_Gerdau.WS_Gerdau {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://TorresOcaranza.cl/", ConfigurationName="WS_Gerdau.WS_IntegracionGerdauSoap")]
    public interface WS_IntegracionGerdauSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerDatosPorEnviar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau[] ObtenerDatosPorEnviar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerDatosPorEnviar", ReplyAction="*")]
        System.Threading.Tasks.Task<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau[]> ObtenerDatosPorEnviarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerDatosDetalle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Gestor_OC_Gerdau.WS_Gerdau.Detalle[] ObtenerDatosDetalle(string iCorrelativo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerDatosDetalle", ReplyAction="*")]
        System.Threading.Tasks.Task<Gestor_OC_Gerdau.WS_Gerdau.Detalle[]> ObtenerDatosDetalleAsync(string iCorrelativo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GrabarArchivo(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GrabarArchivoAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivoFTP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GrabarArchivoFTP(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivoFTP", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GrabarArchivoFTPAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/SolicitudMP_OptiSteelPorSucursal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SolicitudMP_OptiSteelPorSucursal(string iSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/SolicitudMP_OptiSteelPorSucursal", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SolicitudMP_OptiSteelPorSucursalAsync(string iSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivoEnvioMail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GrabarArchivoEnvioMail(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/GrabarArchivoEnvioMail", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GrabarArchivoEnvioMailAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerArchivoPorSubir", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ObtenerArchivoPorSubir();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerArchivoPorSubir", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerArchivoPorSubirAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerViajesCerificar_PorSucursal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ObtenerViajesCerificar_PorSucursal(string iSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerViajesCerificar_PorSucursal", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerViajesCerificar_PorSucursalAsync(string iSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerArchivosParaEnviarCorreoPorOC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ObtenerArchivosParaEnviarCorreoPorOC();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/ObtenerArchivosParaEnviarCorreoPorOC", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerArchivosParaEnviarCorreoPorOCAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/EnviarCorreoNotificacion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string EnviarCorreoNotificacion(string iOrigen, string iMsg, int iObra, string iTitulo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/EnviarCorreoNotificacion", ReplyAction="*")]
        System.Threading.Tasks.Task<string> EnviarCorreoNotificacionAsync(string iOrigen, string iMsg, int iObra, string iTitulo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/PersisteSKU", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string PersisteSKU(System.Data.DataSet iDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/PersisteSKU", ReplyAction="*")]
        System.Threading.Tasks.Task<string> PersisteSKUAsync(System.Data.DataSet iDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/PersisteViajeOpt", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string PersisteViajeOpt(System.Data.DataSet iDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TorresOcaranza.cl/PersisteViajeOpt", ReplyAction="*")]
        System.Threading.Tasks.Task<string> PersisteViajeOptAsync(System.Data.DataSet iDatos);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://TorresOcaranza.cl/")]
    public partial class TipoObjGerdau : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tipoField;
        
        private string rutEmisorField;
        
        private string ocField;
        
        private string clasePedidoField;
        
        private string monedaField;
        
        private string contratoField;
        
        private string fechaPedidoField;
        
        private string usuarioField;
        
        private string vendedorField;
        
        private string clienteField;
        
        private string direccionEntregaField;
        
        private string comunaField;
        
        private string ciudadField;
        
        private string incotermsField;
        
        private string correlativoField;
        
        private string codigoDireccionField;
        
        private string errorsField;
        
        private Detalle[] detalleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
                this.RaisePropertyChanged("Tipo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RutEmisor {
            get {
                return this.rutEmisorField;
            }
            set {
                this.rutEmisorField = value;
                this.RaisePropertyChanged("RutEmisor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string OC {
            get {
                return this.ocField;
            }
            set {
                this.ocField = value;
                this.RaisePropertyChanged("OC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ClasePedido {
            get {
                return this.clasePedidoField;
            }
            set {
                this.clasePedidoField = value;
                this.RaisePropertyChanged("ClasePedido");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Moneda {
            get {
                return this.monedaField;
            }
            set {
                this.monedaField = value;
                this.RaisePropertyChanged("Moneda");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Contrato {
            get {
                return this.contratoField;
            }
            set {
                this.contratoField = value;
                this.RaisePropertyChanged("Contrato");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string FechaPedido {
            get {
                return this.fechaPedidoField;
            }
            set {
                this.fechaPedidoField = value;
                this.RaisePropertyChanged("FechaPedido");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
                this.RaisePropertyChanged("Usuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Vendedor {
            get {
                return this.vendedorField;
            }
            set {
                this.vendedorField = value;
                this.RaisePropertyChanged("Vendedor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Cliente {
            get {
                return this.clienteField;
            }
            set {
                this.clienteField = value;
                this.RaisePropertyChanged("Cliente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string DireccionEntrega {
            get {
                return this.direccionEntregaField;
            }
            set {
                this.direccionEntregaField = value;
                this.RaisePropertyChanged("DireccionEntrega");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Comuna {
            get {
                return this.comunaField;
            }
            set {
                this.comunaField = value;
                this.RaisePropertyChanged("Comuna");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string Ciudad {
            get {
                return this.ciudadField;
            }
            set {
                this.ciudadField = value;
                this.RaisePropertyChanged("Ciudad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string Incoterms {
            get {
                return this.incotermsField;
            }
            set {
                this.incotermsField = value;
                this.RaisePropertyChanged("Incoterms");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string Correlativo {
            get {
                return this.correlativoField;
            }
            set {
                this.correlativoField = value;
                this.RaisePropertyChanged("Correlativo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string CodigoDireccion {
            get {
                return this.codigoDireccionField;
            }
            set {
                this.codigoDireccionField = value;
                this.RaisePropertyChanged("CodigoDireccion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string Errors {
            get {
                return this.errorsField;
            }
            set {
                this.errorsField = value;
                this.RaisePropertyChanged("Errors");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=17)]
        public Detalle[] Detalle {
            get {
                return this.detalleField;
            }
            set {
                this.detalleField = value;
                this.RaisePropertyChanged("Detalle");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://TorresOcaranza.cl/")]
    public partial class Detalle : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tipoField;
        
        private string rutEmisorField;
        
        private string ocField;
        
        private string posicionField;
        
        private string materialField;
        
        private string descripcionField;
        
        private string almacenField;
        
        private string familiaProductoField;
        
        private string cantidadField;
        
        private string unidadMedidaField;
        
        private string precioField;
        
        private string montoField;
        
        private string descuentoField;
        
        private string fechaEstimadaEntregaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
                this.RaisePropertyChanged("Tipo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RutEmisor {
            get {
                return this.rutEmisorField;
            }
            set {
                this.rutEmisorField = value;
                this.RaisePropertyChanged("RutEmisor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string OC {
            get {
                return this.ocField;
            }
            set {
                this.ocField = value;
                this.RaisePropertyChanged("OC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Posicion {
            get {
                return this.posicionField;
            }
            set {
                this.posicionField = value;
                this.RaisePropertyChanged("Posicion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Material {
            get {
                return this.materialField;
            }
            set {
                this.materialField = value;
                this.RaisePropertyChanged("Material");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Almacen {
            get {
                return this.almacenField;
            }
            set {
                this.almacenField = value;
                this.RaisePropertyChanged("Almacen");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string FamiliaProducto {
            get {
                return this.familiaProductoField;
            }
            set {
                this.familiaProductoField = value;
                this.RaisePropertyChanged("FamiliaProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Cantidad {
            get {
                return this.cantidadField;
            }
            set {
                this.cantidadField = value;
                this.RaisePropertyChanged("Cantidad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string UnidadMedida {
            get {
                return this.unidadMedidaField;
            }
            set {
                this.unidadMedidaField = value;
                this.RaisePropertyChanged("UnidadMedida");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Precio {
            get {
                return this.precioField;
            }
            set {
                this.precioField = value;
                this.RaisePropertyChanged("Precio");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Monto {
            get {
                return this.montoField;
            }
            set {
                this.montoField = value;
                this.RaisePropertyChanged("Monto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string Descuento {
            get {
                return this.descuentoField;
            }
            set {
                this.descuentoField = value;
                this.RaisePropertyChanged("Descuento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string FechaEstimadaEntrega {
            get {
                return this.fechaEstimadaEntregaField;
            }
            set {
                this.fechaEstimadaEntregaField = value;
                this.RaisePropertyChanged("FechaEstimadaEntrega");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://TorresOcaranza.cl/")]
    public partial class ArchivosGerdau : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nombreField;
        
        private string estadoField;
        
        private string obsField;
        
        private string pathField;
        
        private string adqOdNuReField;
        
        private string adqOdNumField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("Nombre");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
                this.RaisePropertyChanged("Estado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Obs {
            get {
                return this.obsField;
            }
            set {
                this.obsField = value;
                this.RaisePropertyChanged("Obs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
                this.RaisePropertyChanged("Path");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string AdqOdNuRe {
            get {
                return this.adqOdNuReField;
            }
            set {
                this.adqOdNuReField = value;
                this.RaisePropertyChanged("AdqOdNuRe");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string AdqOdNum {
            get {
                return this.adqOdNumField;
            }
            set {
                this.adqOdNumField = value;
                this.RaisePropertyChanged("AdqOdNum");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WS_IntegracionGerdauSoapChannel : Gestor_OC_Gerdau.WS_Gerdau.WS_IntegracionGerdauSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_IntegracionGerdauSoapClient : System.ServiceModel.ClientBase<Gestor_OC_Gerdau.WS_Gerdau.WS_IntegracionGerdauSoap>, Gestor_OC_Gerdau.WS_Gerdau.WS_IntegracionGerdauSoap {
        
        public WS_IntegracionGerdauSoapClient() {
        }
        
        public WS_IntegracionGerdauSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_IntegracionGerdauSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_IntegracionGerdauSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_IntegracionGerdauSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau[] ObtenerDatosPorEnviar() {
            return base.Channel.ObtenerDatosPorEnviar();
        }
        
        public System.Threading.Tasks.Task<Gestor_OC_Gerdau.WS_Gerdau.TipoObjGerdau[]> ObtenerDatosPorEnviarAsync() {
            return base.Channel.ObtenerDatosPorEnviarAsync();
        }
        
        public Gestor_OC_Gerdau.WS_Gerdau.Detalle[] ObtenerDatosDetalle(string iCorrelativo) {
            return base.Channel.ObtenerDatosDetalle(iCorrelativo);
        }
        
        public System.Threading.Tasks.Task<Gestor_OC_Gerdau.WS_Gerdau.Detalle[]> ObtenerDatosDetalleAsync(string iCorrelativo) {
            return base.Channel.ObtenerDatosDetalleAsync(iCorrelativo);
        }
        
        public string GrabarArchivo(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivo(iObjArchivo);
        }
        
        public System.Threading.Tasks.Task<string> GrabarArchivoAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivoAsync(iObjArchivo);
        }
        
        public string GrabarArchivoFTP(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivoFTP(iObjArchivo);
        }
        
        public System.Threading.Tasks.Task<string> GrabarArchivoFTPAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivoFTPAsync(iObjArchivo);
        }
        
        public System.Data.DataSet SolicitudMP_OptiSteelPorSucursal(string iSucursal) {
            return base.Channel.SolicitudMP_OptiSteelPorSucursal(iSucursal);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SolicitudMP_OptiSteelPorSucursalAsync(string iSucursal) {
            return base.Channel.SolicitudMP_OptiSteelPorSucursalAsync(iSucursal);
        }
        
        public string GrabarArchivoEnvioMail(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivoEnvioMail(iObjArchivo);
        }
        
        public System.Threading.Tasks.Task<string> GrabarArchivoEnvioMailAsync(Gestor_OC_Gerdau.WS_Gerdau.ArchivosGerdau iObjArchivo) {
            return base.Channel.GrabarArchivoEnvioMailAsync(iObjArchivo);
        }
        
        public System.Data.DataSet ObtenerArchivoPorSubir() {
            return base.Channel.ObtenerArchivoPorSubir();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerArchivoPorSubirAsync() {
            return base.Channel.ObtenerArchivoPorSubirAsync();
        }
        
        public System.Data.DataSet ObtenerViajesCerificar_PorSucursal(string iSucursal) {
            return base.Channel.ObtenerViajesCerificar_PorSucursal(iSucursal);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerViajesCerificar_PorSucursalAsync(string iSucursal) {
            return base.Channel.ObtenerViajesCerificar_PorSucursalAsync(iSucursal);
        }
        
        public System.Data.DataSet ObtenerArchivosParaEnviarCorreoPorOC() {
            return base.Channel.ObtenerArchivosParaEnviarCorreoPorOC();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerArchivosParaEnviarCorreoPorOCAsync() {
            return base.Channel.ObtenerArchivosParaEnviarCorreoPorOCAsync();
        }
        
        public string EnviarCorreoNotificacion(string iOrigen, string iMsg, int iObra, string iTitulo) {
            return base.Channel.EnviarCorreoNotificacion(iOrigen, iMsg, iObra, iTitulo);
        }
        
        public System.Threading.Tasks.Task<string> EnviarCorreoNotificacionAsync(string iOrigen, string iMsg, int iObra, string iTitulo) {
            return base.Channel.EnviarCorreoNotificacionAsync(iOrigen, iMsg, iObra, iTitulo);
        }
        
        public string PersisteSKU(System.Data.DataSet iDatos) {
            return base.Channel.PersisteSKU(iDatos);
        }
        
        public System.Threading.Tasks.Task<string> PersisteSKUAsync(System.Data.DataSet iDatos) {
            return base.Channel.PersisteSKUAsync(iDatos);
        }
        
        public string PersisteViajeOpt(System.Data.DataSet iDatos) {
            return base.Channel.PersisteViajeOpt(iDatos);
        }
        
        public System.Threading.Tasks.Task<string> PersisteViajeOptAsync(System.Data.DataSet iDatos) {
            return base.Channel.PersisteViajeOptAsync(iDatos);
        }
    }
}
