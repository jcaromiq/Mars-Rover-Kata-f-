.PHONY: test
test:
	dotnet test MarsRover.Tests 

build:
	dotnet build

watch:
	cd MarsRover.Tests; dotnet watch test