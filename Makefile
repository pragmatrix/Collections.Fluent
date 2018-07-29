msbuild=msbuild.exe /m /verbosity:m /nologo
nuget=nuget.exe

name=Collections.Fluent

.PHONY: distribute
distribute: package distribute-package

.PHONY: package
package: conf=Release
package: 
	cd ${name} && dotnet pack ${name}.csproj -c ${conf}

.PHONY: distribute-package
distribute-package:
	cd ${name} && nuget push ${name}.${ver}.nupkg -source https://www.nuget.org/api/v2/package/ 

.PHONY: build-release
build-release: conf=Release
build-release: build

.PHONY: build
build:
	${msbuild} ${name}.sln /p:Configuration=${conf} /t:"Collections_Fluent:Rebuild;Collections_Fluent_Tests:Rebuild"

