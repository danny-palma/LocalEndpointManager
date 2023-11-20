﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocalEndpointManager_Server_GUI.ServerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerService.ICommunication")]
    public interface ICommunication {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommunication/GetConnectedClientsInfo", ReplyAction="http://tempuri.org/ICommunication/GetConnectedClientsInfoResponse")]
        System.Collections.Generic.Dictionary<string, LocalEndpointManager_InterCommLib.MessageFormat.ProcessInfo[]> GetConnectedClientsInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommunication/GetConnectedClientsInfo", ReplyAction="http://tempuri.org/ICommunication/GetConnectedClientsInfoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, LocalEndpointManager_InterCommLib.MessageFormat.ProcessInfo[]>> GetConnectedClientsInfoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommunicationChannel : LocalEndpointManager_Server_GUI.ServerService.ICommunication, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommunicationClient : System.ServiceModel.ClientBase<LocalEndpointManager_Server_GUI.ServerService.ICommunication>, LocalEndpointManager_Server_GUI.ServerService.ICommunication {
        
        public CommunicationClient() {
        }
        
        public CommunicationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommunicationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommunicationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommunicationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, LocalEndpointManager_InterCommLib.MessageFormat.ProcessInfo[]> GetConnectedClientsInfo() {
            return base.Channel.GetConnectedClientsInfo();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, LocalEndpointManager_InterCommLib.MessageFormat.ProcessInfo[]>> GetConnectedClientsInfoAsync() {
            return base.Channel.GetConnectedClientsInfoAsync();
        }
    }
}
