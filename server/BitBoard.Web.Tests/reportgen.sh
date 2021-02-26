output=$(dotnet test --collect:"XPlat Code Coverage")

passed=$(echo "$output" | grep "Failed:     0")

if test -z "$passed"
then
    echo "Tests Failed"
else
    echo "Tests Passed!"
    attch=$(echo "$output" | grep "Attachments:" -A1)
    covreport=$(echo $attch | cut -d' ' -f2)
    echo "Generated new report $covreport"

    reportgenerator "-reports:$covreport" "-targetdir:coverage-reports" -reporttypes:Html
fi

