# Art-Museum-Trivia

# GitHub - Comandos Básicos

## Configuración Inicial
```sh
# Configurar nombre de usuario
git config --global user.name "Tu Nombre"

# Configurar email
git config --global user.email "tuemail@example.com"

# Ver configuración actual
git config --list
```

## Inicializar un Repositorio
```sh
# Crear un nuevo repositorio
git init

# Clonar un repositorio existente
git clone URL_DEL_REPOSITORIO
```

## Trabajar con Archivos
```sh
# Ver estado del repositorio
git status

# Agregar un archivo al área de preparación
git add nombre_archivo

# Agregar todos los archivos al área de preparación
git add .

# Confirmar cambios (commit)
git commit -m "Mensaje del commit"
```

## Trabajar con Ramas (Branches)
```sh
# Ver ramas existentes
git branch

# Crear una nueva rama
git branch nombre_rama

# Cambiar a otra rama
git checkout nombre_rama

# Crear y cambiar a una nueva rama
git checkout -b nombre_rama
```

## Sincronizar con GitHub
```sh
# Conectar el repositorio local con GitHub
git remote add origin URL_DEL_REPOSITORIO

# Subir cambios al repositorio remoto
git push origin nombre_rama

# Descargar cambios del repositorio remoto
git pull origin nombre_rama
```

## Fusionar Cambios (Merge)
```sh
# Cambiar a la rama principal
git checkout main

# Fusionar otra rama en la principal
git merge nombre_rama
```

## Deshacer Cambios
```sh
# Revertir cambios en un archivo sin confirmar
git checkout -- nombre_archivo

# Restablecer el último commit sin borrar cambios
git reset --soft HEAD~1

# Restablecer el último commit y borrar cambios
git reset --hard HEAD~1
```

## Otros Comandos Útiles
```sh
# Ver historial de commits
git log

# Ver historial en una sola línea
git log --oneline

# Ver cambios realizados en archivos
git diff
```

¡Estos son algunos de los comandos más esenciales para trabajar con Git y GitHub!

