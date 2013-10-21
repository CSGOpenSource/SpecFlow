SCRIPT_DIR="$( cd "$(dirname "$0")" ; pwd -P )"
pushd $SCRIPT_DIR/.. > /dev/null

if [ -d ../Order/ ]; then
	echo Copying TechTalk.SpecFlow.dll to Order...
	cp Runtime/bin/Debug/TechTalk.SpecFlow.* ../Order/Lib/Debug/
fi

if [ -d ../ACPxOrder/ ]; then
	echo Copying TechTalk.SpecFlow.dll to ACPxOrder...
	cp Runtime/bin/Debug/TechTalk.SpecFlow.* ../ACPxOrder/Lib/Debug/
fi

popd > /dev/null