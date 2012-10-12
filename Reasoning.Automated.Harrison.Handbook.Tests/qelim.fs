﻿// ========================================================================= //
// Copyright (c) 2003-2007, John Harrison.                                   //
// Copyright (c) 2012 Eric Taucher, Jack Pappas, Anh-Dung Phan               //
// (See "LICENSE.txt" for details.)                                          //
// ========================================================================= //

module FSharpx.Books.AutomatedReasoning.Tests.qelim

open NUnit.Framework
open FsUnit

open FSharpx.Books.AutomatedReasoning.lib
open FSharpx.Books.AutomatedReasoning.formulas
open FSharpx.Books.AutomatedReasoning.prop
open FSharpx.Books.AutomatedReasoning.fol
open FSharpx.Books.AutomatedReasoning.skolem
open FSharpx.Books.AutomatedReasoning.equal
open FSharpx.Books.AutomatedReasoning.decidable
open FSharpx.Books.AutomatedReasoning.qelim

// pg. 335
//  ------------------------------------------------------------------------- // 
//  Examples.                                                                 // 
//  ------------------------------------------------------------------------- // 

[<TestCase(@"forall x y. exists z. z < x /\ z < y", "true")>]
[<TestCase(@"exists z. z < x /\ z < y", "true")>]
[<TestCase(@"exists z. x < z /\ z < y", "x < y")>]
[<TestCase(@"(forall x. x < a ==> x < b)", "~(b < a \/ b < a)")>]
[<TestCase(@"forall a b. (forall x. x < a ==> x < b) <=> a <= b", "true")>]
[<TestCase(@"forall a b. (forall x. x < a <=> x < b) <=> a = b", "true")>]
[<TestCase(@"exists x y z. forall u.
					x < x \/ ~x < u \/ (x < y /\ y < z /\ ~x < z)", "false")>]
[<TestCase(@"forall x. exists y. x < y", "true")>]
[<TestCase(@"forall x y z. x < y /\ y < z ==> x < z", "true")>]
[<TestCase(@"forall x y. x < y \/ (x = y) \/ y < x", "true")>]
[<TestCase(@"exists x y. x < y /\ y < x", "false")>]
[<TestCase(@"forall x y. exists z. z < x /\ x < y", "false")>]
[<TestCase(@"exists z. z < x /\ x < y", "x < y")>]
[<TestCase(@"forall x y. x < y ==> exists z. x < z /\ z < y", "true")>]
[<TestCase(@"forall x y. ~(x = y) ==> exists u. u < x /\ (y < u \/ x < y)", "true")>]
[<TestCase(@"exists z. x < z /\ z < y", "x < y")>]
[<TestCase(@"exists z. x <= z /\ z <= y", "x < y \/ x < y \/ x <y \/ y = x")>] // Can be simplified
[<TestCase(@"exists z. x < z /\ z <= y", "x < y \/ x < y")>] // Can be simplified
[<TestCase(@"forall x y z. exists u. u < x /\ u < y /\ u < z", "true")>]
[<TestCase(@"forall y. x < y /\ y < z ==> w < z", "~(x < z /\ ~(w < z))")>]
[<TestCase(@"forall a b. exists x. ~(x = a) \/ ~(x = b) \/ (a = b)", "true")>]
[<TestCase(@"forall x y. x <= y \/ x > y", "true")>]
[<TestCase(@"forall x y. x <= y \/ x < y", "false")>]
let ``quelim_dlo`` (input, expected) =
    quelim_dlo (parse input)
    |> should equal (parse expected)

