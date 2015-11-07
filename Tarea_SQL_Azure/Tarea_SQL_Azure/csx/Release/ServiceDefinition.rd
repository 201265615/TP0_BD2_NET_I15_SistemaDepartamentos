<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Tarea_SQL_Azure" generation="1" functional="0" release="0" Id="875e67b6-a6d4-4532-96a6-d78915c73252" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Tarea_SQL_AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="TareaServiceWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/LB:TareaServiceWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="TareaServiceWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/MapTareaServiceWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:TareaServiceWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapTareaServiceWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="TareaServiceWebRole" generation="1" functional="0" release="0" software="C:\Users\kevem94\documents\visual studio 2013\Projects\Tarea_SQL_Azure\Tarea_SQL_Azure\csx\Release\roles\TareaServiceWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;TareaServiceWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;TareaServiceWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="TareaServiceWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="TareaServiceWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="TareaServiceWebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="0f10e466-29f3-406b-811c-fc8f6184906e" ref="Microsoft.RedDog.Contract\ServiceContract\Tarea_SQL_AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="460467b3-e275-434a-918a-6a8ea3aa1bff" ref="Microsoft.RedDog.Contract\Interface\TareaServiceWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>