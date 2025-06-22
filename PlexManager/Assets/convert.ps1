# Chemins d'entrée et de sortie
$File = "D:\Github\AnthoDingo\PlexManager\PlexManager\Assets\logo-notitle-nobackground.png"
$Export = "D:\Github\AnthoDingo\PlexManager\PlexManager\Assets\logo-notitle-nobackground.svg"

# Lecture de l'image en base64
$ImageBytes = Get-Content -Path $File -AsByteStream
$Base64Image = [Convert]::ToBase64String($ImageBytes)

# Récupération des dimensions de l'image
Add-Type -AssemblyName System.Drawing
$Bitmap = [System.Drawing.Image]::FromFile($File)
$Width = $Bitmap.Width
$Height = $Bitmap.Height

# Construction du SVG
$SVG = @"
<?xml version="1.0" standalone="no"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 20010904//EN"
 "http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd">
<svg xmlns="http://www.w3.org/2000/svg" width="$Width" height="$Height">
  <image width="$Width" height="$Height" href="data:image/png;base64,$Base64Image" />
</svg>
"@

# Écriture du fichier SVG
$SVG | Out-File -FilePath $Export -Encoding utf8 -Force