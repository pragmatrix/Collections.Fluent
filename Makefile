msbuild=msbuild.exe /m /verbosity:m /nologo
nuget=nuget.exe

name=Collections.Fluent
version=0.4.0

.PHONY: distribute
distribute: package distribute-package

.PHONY: package
package: conf=Release
package: 
	cd ${name} && dotnet pack ${name}.csproj -c ${conf} /p:PackageVersion=${version}

.PHONY: publish
publish: conf=Release
publish: package
	cd ${name}/bin/${conf} && ${nuget} push ${name}.${version}.nupkg -source https://www.nuget.org/api/v2/package/ 

.PHONY: build-release
build-release: conf=Release
build-release: build

.PHONY: build
build:
	${msbuild} ${name}.sln /p:Configuration=${conf} /t:"Collections_Fluent:Rebuild;Collections_Fluent_Tests:Rebuild"

