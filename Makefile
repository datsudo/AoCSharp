PROJ_NAME=AoCSharp
BIN_PATH=./bin/Debug/net7.0


build:
	@dotnet build

run:
	@make build
	dotnet $(BIN_PATH)/$(PROJ_NAME).dll
