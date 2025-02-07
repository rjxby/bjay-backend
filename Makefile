# Project variables
IMAGE_NAME := bjay
DOCKER_RUN_OPTIONS := -p 7070:8080

# Help target
.PHONY: help
help:
	@echo "Available commands:"
	@echo "  dev              - Run application in development mode"
	@echo "  db-migrate       - Apply database migrations"
	@echo "  db-add          - Add new migration (usage: make db-add name=MigrationName)"
	@echo "  docker-build    - Build Docker image"
	@echo "  docker-run      - Build and run Docker image"

# Development commands
.PHONY: dev
dev:
	dotnet run --project ./Backend/Api/Host

# Database commands
.PHONY: db-migrate db-add
db-migrate:
	dotnet ef database update \
		--startup-project ./Backend/Api/Host \
		--project ./Backend/Api/Repositories/Implimentation

db-add:
	@if [ -z "$(name)" ]; then \
		echo "Error: Migration name is required"; \
		echo "Usage: make db-add name=MigrationName"; \
		exit 1; \
	fi
	dotnet ef migrations add $(name) \
		--startup-project ./Backend/Api/Host \
		--project ./Backend/Api/Repositories/Implimentation

# Docker commands
.PHONY: docker-build docker-run
docker-build:
	docker build \
		--no-cache \
		-t $(IMAGE_NAME) \
		-f Backend/Api/Host/Dockerfile ./Backend

docker-run: docker-build
	docker run $(DOCKER_RUN_OPTIONS) $(IMAGE_NAME)

.DEFAULT_GOAL := help