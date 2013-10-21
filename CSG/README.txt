This directory contains CSG specific scripts, configuration, etc that should not ever be pushed back to the original TechTalk repository.

copy-local.sh
* Copies updated assemblies into your local module's lib directory.

csg-build.sh
* Runs a slimmed down build of only the assemblies that we require for own own modules. Copies output to Bin at the root of the directory so we can easily stage it.

CSG-TechTalk.SpecFlow.sln
* A VS2012 solution that contains only the projects we require.
* Lives in root / solution directory to make life easier as projects reference everything according to the solution dir.
