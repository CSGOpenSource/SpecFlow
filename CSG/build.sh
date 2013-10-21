SCRIPT_DIR="$( cd "$(dirname "$0")" ; pwd -P )"
pushd $SCRIPT_DIR/.. > /dev/null

echo Build DEBUG...
/c/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe CSG-TechTalk.SpecFlow.sln //p:Configuration=Debug //clp:ErrorsOnly //m

echo Build RELEASE...
/c/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe CSG-TechTalk.SpecFlow.sln //p:Configuration=Release //clp:ErrorsOnly //m

echo Copying TechTalk.SpecFlow output...
mkdir -p Bin
mkdir -p Bin/Debug
mkdir -p Bin/Release

cp lib/gherkin/Gherkin.dll Bin/Debug/
cp lib/gherkin/Gherkin.dll Bin/Release/

cp lib/gherkin/IKVM.*.dll Bin/Debug/
cp lib/gherkin/IKVM.*.dll Bin/Release/

cp Runtime/bin/Debug/TechTalk.SpecFlow.dll Bin/Debug/
cp Runtime/bin/Release/TechTalk.SpecFlow.dll Bin/Release/

cp Generator/bin/Debug/TechTalk.SpecFlow.Generator.dll Bin/Debug/
cp Generator/bin/Release/TechTalk.SpecFlow.Generator.dll Bin/Release/

cp IdeIntegration/IdeIntegration/bin/Debug/TechTalk.SpecFlow.IdeIntegration.dll Bin/Debug/
cp IdeIntegration/IdeIntegration/bin/Release/TechTalk.SpecFlow.IdeIntegration.dll Bin/Release/

cp Parser/bin/Debug/TechTalk.SpecFlow.Parser.dll Bin/Debug/
cp Parser/bin/Release/TechTalk.SpecFlow.Parser.dll Bin/Release/

cp Utils/bin/Debug/TechTalk.SpecFlow.Utils.dll Bin/Debug/
cp Utils/bin/Release/TechTalk.SpecFlow.Utils.dll Bin/Release/

cp IdeIntegration/Vs2010Integration/bin/Debug/TechTalk.SpecFlow.Vs2010Integration.dll Bin/Debug/
cp IdeIntegration/Vs2010Integration/bin/Release/TechTalk.SpecFlow.Vs2010Integration.dll Bin/Release/

popd > /dev/null