<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Tarea_SQL_Azure" generation="1" functional="0" release="0" Id="efb6ae5d-e28c-427e-85e2-b916e3f2662e" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
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
          <role name="TareaServiceWebRole" generation="1" functional="0" release="0" software="C:\Users\kevem94\documents\visual studio 2013\Projects\Tarea_SQL_Azure\Tarea_SQL_Azure\csx\Debug\roles\TareaServiceWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
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
    <implementation Id="04716ca5-a9a3-43e3-a525-6d618b9bf501" ref="Microsoft.RedDog.Contract\ServiceContract\Tarea_SQL_AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="8ca27573-50c1-4f60-8737-26a5c1e8b01e" ref="Microsoft.RedDog.Contract\Interface\TareaServiceWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Tarea_SQL_Azure/Tarea_SQL_AzureGroup/TareaServiceWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>