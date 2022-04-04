docker build -t measurement-api:1.0 . -f ./Measurement.WebApi/Dockerfile 
docker run -d -p 8080:80 -p 5001:443  -t measurement-api:1.0 