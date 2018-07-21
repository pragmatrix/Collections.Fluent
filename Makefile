msbuild=msbuild.exe /m /verbosity:m /nologo
nuget=nuget.exe

ver=1.0.0-pre
name=Collections.Fluent

.PHONY: distribute
distribute: package distribute-package

.PHONY: package
package: conf=Release
package: build
	cd ${name} && ${nuget} pack ${name}.csproj -Version ${ver} -Prop Configuration=${conf} 
.PHONY: distribute-package
distribute-package:
	cd ${name} && nuget push ${name}.${ver}.nupkg -source https://www.nuget.org/api/v2/package/ 

.PHONY: build-release
build-release: conf=Release
build-release: build

.PHONY: build
build:
	${msbuild} ${name}.sln /p:Configuration=${conf} /t:"Collections_Fluent:Rebuild;Collections_Fluent_Tests:Rebuild"

.PHONY: update-nuget
update-nuget:
	mkdir -p ~/bin/ 
	rm -f ~/bin/nuget.exe
	cd ~/bin && wget https://www.nuget.org/nuget.exe && chmod +x nuget.exe
	
