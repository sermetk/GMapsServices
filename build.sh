#!/bin/bash

SCRIPTDIR="$(dirname "$0")"

echo running unit tests
dotnet test $SCRIPTDIR/GMapsServices/test/GMapsServices.UnitTests/GMapsServices.UnitTests.csproj

echo running integration tests
dotnet test $SCRIPTDIR/GMapsServices/test/GMapsServices.IntegrationTests/GMapsServices.IntegrationTests.csproj

echo running acceptance tests
dotnet test $SCRIPTDIR/GMapsServices/test/GMapsServices.AcceptanceTests/GMapsServices.AcceptanceTests.csproj

cd $SCRIPTDIR/GMapsServices

docker-compose up