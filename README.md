## GMapsServices
Google Maps API Wrapper

### Contents
- Autocomplete
- Place Detail
- Directions
- Geocode

## Getting Started

### Prerequisites
 - docker

### Configuration
There are three actively used environment variables:\
\
 **Production**: Used by Docker Compose. \
\
 **Development**: Used at local debugging. Dependings must be running locally. \
\
 **Test**: Used by [Testcontainers](https://github.com/HofmeisterAn/dotnet-testcontainers).

### Installing
Clone repository:
```
https://github.com/sermetk/GMapsServices.git
```
Set container orchestration as startup project or use docker-compose up command. Docker-compose.yml includes Api, Postgresql and Seq. So, you don't need any other setup. 

As a different method, if you want to run the tests first and then compile you can use build.sh script which located on root:

#### Build
```
unix: sh {script path}
windows: bash {script path} -if you use wsl-
```

### Api Documentation
Swagger UI:
```
http://localhost:5001
```

### Logs
Seq UI:
```
http://localhost:5341
```

### Test
You can use build scripts or run tests via visual studio. 
Before running the tests, make sure that port 5342 used by the Postgre server is free.