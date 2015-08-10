// include Fake lib
#r "tools/FAKE/tools/FakeLib.dll"

open Fake

// Targets
Target "Clean" (fun _ ->
    !!"./**/bin/**" |> DeleteDirs
    !!"./**/obj/**" |> DeleteDirs
)

let restorePackages() = RestoreMSSolutionPackages (fun p -> { p with OutputPath = "./packages" }) "./SmallestThingThatWillWork.sln"

let build () = 
    !! "./**/*.csproj"
      |> MSBuildWithDefaults "Build"
      |> Log "AppBuild-Output: "

Target "Build" build
Target "Restore" restorePackages

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

let tests () =
    !! ("./**/bin/Release/SmallestThingThatWillWork.dll")
        |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = "./TestResults.xml" })

Target "Tests" tests

// Dependencies
"Clean" 
    ==> "Restore"
    ==> "Build"
    ==> "Tests"
    ==> "Default"

// start build
RunTargetOrDefault "Default"