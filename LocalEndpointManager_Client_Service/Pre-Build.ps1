param (
    [string]$serviceName
)

# Verificar si se proporcionó un nombre de servicio
if (-not $serviceName) {
    Write-Host "Por favor, proporciona el nombre del servicio como argumento."
    exit 1
}

# Verificar si el servicio está instalado
$serviceInstalled = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

if ($serviceInstalled) {
    # Verificar si el servicio está en ejecución
    if ($serviceInstalled.Status -eq 'Running') {
        Write-Host "El servicio '$serviceName' está en ejecución. Deteniendo el servicio..."
        
        # Detener el servicio
        Stop-Service -Name $serviceName
        Write-Host "El servicio '$serviceName' se detuvo correctamente."
    } else {
        Write-Host "El servicio '$serviceName' está instalado pero no está en ejecución. No se realiza ninguna acción."
    }
} else {
    Write-Host "El servicio '$serviceName' no está instalado. No se realiza ninguna acción."
}
