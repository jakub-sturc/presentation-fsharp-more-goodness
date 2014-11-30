#I @"packages/FsReveal/fsreveal/"
#I @"packages/FAKE/tools/"
#I @"packages/RazorEngine/lib/net40/"

#r "FakeLib.dll"

#load "fsreveal.fsx"

open FsReveal
open Fake
open System.IO
open System.Diagnostics


let outputDir = "./Slides/"

Target "CleanSlides" (fun _ ->
    CleanDirs [outputDir]
)

Target "GenerateSlides" (fun _ ->
    FsReveal.GenerateOutputFromMarkdownFile outputDir "presentation.html" "./input.md"
)

"CleanSlides"
  ==> "GenerateSlides"

RunTargetOrDefault "GenerateSlides"