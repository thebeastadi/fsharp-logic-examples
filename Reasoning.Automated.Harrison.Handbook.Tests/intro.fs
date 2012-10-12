﻿// ========================================================================= //
// Copyright (c) 2003-2007, John Harrison.                                   //
// Copyright (c) 2012 Eric Taucher, Jack Pappas, Anh-Dung Phan               //
// (See "LICENSE.txt" for details.)                                          //
// ========================================================================= //

module FSharpx.Books.AutomatedReasoning.Tests.intro

open FSharpx.Books.AutomatedReasoning.lib
open FSharpx.Books.AutomatedReasoning.intro
open NUnit.Framework
open FsUnit

// pg. 16
// ------------------------------------------------------------------------- //
// Example.                                                                  //
// ------------------------------------------------------------------------- //

[<Test>]
let ``simplify``() =
    simplify (Add (Mul (Add (Mul (Const 0, Var "x"), Const 1), Const 3), Const 12)) 
    |> should equal (Const 15)

[<Test>]
let ``lex simple``() =
    lex (explode "2*((var_1 + x') + 11)")
    |> should equal ["2"; "*"; "("; "("; "var_1"; "+"; "x'"; ")"; "+"; "11"; ")"]

[<Test>]
let ``lex if-then-else``() =
    lex (explode "if //p1-- == *p2++) then f() else g()")
    |> should equal ["if"; "//"; "p1"; "--"; "=="; "*"; "p2"; "++"; ")"; "then"; "f"; "("; ")"; "else"; "g"; "("; ")"]

// pg. 20
// ------------------------------------------------------------------------- //
// Our parser.                                                               //
// ------------------------------------------------------------------------- //

[<Test>]
let ``parse_exp simple``() =
    parse_exp "x + 1"
    |> should equal (Add (Var "x",Const 1))

// pg. 21
// ------------------------------------------------------------------------- //
// Demonstrate automatic installation.                                       //
// ------------------------------------------------------------------------- //

[<Test>]
let ``parse_exp complex``() =
    parse_exp "(x1 + x2 + x3) * (1 + 2 + 3 * x + y)"
    |> should equal (Mul (Add (Var "x1",Add (Var "x2",Var "x3")), 
                            Add (Const 1,Add (Const 2,Add (Mul (Const 3,Var "x"),Var "y")))))

// pg. 21
// ------------------------------------------------------------------------- //
// Examples.                                                                 //
// ------------------------------------------------------------------------- //

[<Test>]
let ``string_of_exp``() =
    string_of_exp (parse_exp "x + 3 * y")
    |> should equal "(x + (3 * y))"