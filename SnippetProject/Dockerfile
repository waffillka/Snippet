#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SnippetProject/SnippetProject.csproj", "SnippetProject/"]
COPY ["Snippet.Common/Snippet.Common.csproj", "Snippet.Common/"]
COPY ["Snippet.Services/Snippet.Services.csproj", "Snippet.Services/"]
COPY ["Snippet.Data/Snippet.Data.csproj", "Snippet.Data/"]
COPY ["Snippet.Authentication/Snippet.Authentication.csproj", "Snippet.Authentication/"]
RUN dotnet restore "SnippetProject/SnippetProject.csproj"
COPY . .
WORKDIR "/src/SnippetProject"
RUN dotnet build "SnippetProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnippetProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnippetProject.dll"]