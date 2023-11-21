param (
    [string]$serviceName
)

# Verificar si se proporcion� un nombre de servicio
if (-not $serviceName) {
    Write-Host "Por favor, proporciona el nombre del servicio como argumento."
    exit 1
}

# Verificar si el servicio est� instalado
$serviceInstalled = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

if ($serviceInstalled) {
    # Verificar si el servicio est� en ejecuci�n
    if ($serviceInstalled.Status -eq 'Running') {
        Write-Host "El servicio '$serviceName' est� en ejecuci�n. Deteniendo el servicio..."
        
        # Detener el servicio
        Stop-Service -Name $serviceName
        Write-Host "El servicio '$serviceName' se detuvo correctamente."
    } else {
        Write-Host "El servicio '$serviceName' est� instalado pero no est� en ejecuci�n. No se realiza ninguna acci�n."
    }
} else {
    Write-Host "El servicio '$serviceName' no est� instalado. No se realiza ninguna acci�n."
}
