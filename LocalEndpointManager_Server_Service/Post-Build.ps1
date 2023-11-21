param (
    [string]$serviceName,
    [string]$rutaArchivoBinario,
    [string]$Descripcion
)

if (-not $serviceName -or -not $rutaArchivoBinario -or -not $Descripcion) {
    Write-Host "Por favor, proporciona los argumentos completos."
    exit 1
}

# Verificar si el servicio está instalado
if (Get-Service -Name $serviceName -ErrorAction SilentlyContinue) {
    # Servicio instalado: editar el archivo de configuración
    sc.exe config $serviceName binPath=$rutaArchivoBinario
    Write-Host "Se ha editado el servicio."
} else {
    # Servicio no instalado: instalar el servicio
    Write-Host "El servicio no está instalado. Instalando el servicio..."

    # Código para instalar el servicio en Windows 10
    New-Service -Name $serviceName -DisplayName $Descripcion -StartupType Automatic -BinaryPathName $rutaArchivoBinario

    Write-Host "Se ha instalado el servicio y editado el archivo de configuración."
}

# Código para iniciar el servicio (sustituir con el comando real)
# Por ejemplo, puedes usar Start-Service o sc.exe para iniciar el servicio

Write-Host "Iniciando el servicio..."

Start-Service -Name $serviceName
