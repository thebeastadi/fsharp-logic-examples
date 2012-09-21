﻿//  Copyright (c) 2003-2007, John Harrison
//  All rights reserved.
//  
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions
//  are met:
//  
//  * Redistributions of source code must retain the above copyright
//  notice, this list of conditions and the following disclaimer.
//  
//  * Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the following disclaimer in the
//  IMPORTANT:  READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING.
//  By downloading, copying, installing or using the software you agree
//  to this license.  If you do not agree to this license, do not
//  download, install, copy or use the software.
//  
//  Copyright (c) 2003-2007, John Harrison
//  All rights reserved.
//  
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions
//  are met:
//  
//  * Redistributions of source code must retain the above copyright
//  notice, this list of conditions and the following disclaimer.
//  
//  * Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the following disclaimer in the
//  documentation and/or other materials provided with the distribution.
//  
//  * The name of John Harrison may not be used to endorse or promote
//  products derived from this software without specific prior written
//  permission.
//  
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
//  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
//  SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
//  LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
//  USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//  ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
//  OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
//  SUCH DAMAGE.
// 
//  ===================================================================
// 
//  Converted to F# 2.0
// 
//  Copyright (c) 2012, Eric Taucher
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions
//  are met:
//  
//  * Redistributions of source code must retain the above copyright
//  notice, this list of conditions and the previous disclaimer.
//  
//  * Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the previous disclaimer in the
//  documentation and/or other materials provided with the distribution.
//  
//  * The name of Eric Taucher may not be used to endorse or promote
//  products derived from this software without specific prior written
//  permission.
// 
//  ===================================================================

#load "initialization.fsx"

open Reasoning.Automated.Harrison.Handbook.lib
//open Reasoning.Automated.Harrison.Handbook.intro
//open Reasoning.Automated.Harrison.Handbook.formulas
//open Reasoning.Automated.Harrison.Handbook.prop
//open Reasoning.Automated.Harrison.Handbook.propexamples
//open Reasoning.Automated.Harrison.Handbook.defcnf
//open Reasoning.Automated.Harrison.Handbook.dp
//open Reasoning.Automated.Harrison.Handbook.stal
//open Reasoning.Automated.Harrison.Handbook.bdd
open Reasoning.Automated.Harrison.Handbook.folMod
//open Reasoning.Automated.Harrison.Handbook.skolem
//open Reasoning.Automated.Harrison.Handbook.herbrand
//open Reasoning.Automated.Harrison.Handbook.unif
//open Reasoning.Automated.Harrison.Handbook.tableaux
//open Reasoning.Automated.Harrison.Handbook.resolution
//open Reasoning.Automated.Harrison.Handbook.prolog
//open Reasoning.Automated.Harrison.Handbook.meson
//open Reasoning.Automated.Harrison.Handbook.skolems
//open Reasoning.Automated.Harrison.Handbook.equal
open Reasoning.Automated.Harrison.Handbook.cong
//open Reasoning.Automated.Harrison.Handbook.rewrite
//open Reasoning.Automated.Harrison.Handbook.order
//open Reasoning.Automated.Harrison.Handbook.completion
//open Reasoning.Automated.Harrison.Handbook.eqelim
//open Reasoning.Automated.Harrison.Handbook.paramodulation
//open Reasoning.Automated.Harrison.Handbook.decidable
//open Reasoning.Automated.Harrison.Handbook.qelim
open Reasoning.Automated.Harrison.Handbook.cooper
//open Reasoning.Automated.Harrison.Handbook.complex
open Reasoning.Automated.Harrison.Handbook.real
//open Reasoning.Automated.Harrison.Handbook.grobner
//open Reasoning.Automated.Harrison.Handbook.geom
//open Reasoning.Automated.Harrison.Handbook.interpolation
open Reasoning.Automated.Harrison.Handbook.combining

// pg. 440
// ------------------------------------------------------------------------- //
// Running example if we magically knew the interpolant.                     //
// ------------------------------------------------------------------------- //
    
// val it : Reasoning.Automated.Harrison.Handbook.formulas.formula<fol> = True
(integer_qelim >>|> generalize) (parse "(u + 1 = v /\ v_1 + 1 = u - 1 /\ v_2 - 1 = v + 1 /\ v_3 = v - 1) ==> u = v_3 /\ ~(v_1 = v_2)");;

// val it : bool = true
ccvalid (parse "(v_2 = f(v_3) /\ v_1 = f(u)) ==> ~(u = v_3 /\ ~(v_1 = v_2))");;
        
// pg. 444
// ------------------------------------------------------------------------- //
// Check that our example works.                                             //
// ------------------------------------------------------------------------- //

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop001 (add_default [int_lang])  (parse "f(v - 1) - 1 = v + 1 /\ f(u) + 1 = u - 1 /\ u + 1 = v ==> false");;
     
// pg. 444
// ------------------------------------------------------------------------- //
// Bell numbers show the size of our case analysis.                          //
// ------------------------------------------------------------------------- //

// val it : int list = [1; 2; 5; 15; 52; 203; 877; 4140; 21147; 115975]
let bell n = List.length(allpartitions (1--n)) in List.map bell (1 -- 10);;
            
// pg. 446
// ------------------------------------------------------------------------- //
// Some additional examples (from ICS paper and Shostak's "A practical..."   //
// ------------------------------------------------------------------------- //

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop (add_default [int_lang]) (parse "y <= x /\ y >= x + z /\ z >= 0 ==> f(f(x) - f(y)) = f(z)");;

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop (add_default [int_lang]) (parse "x = y /\ y >= z /\ z >= x ==> f(z) = f(x)");;

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop (add_default [int_lang]) (parse "a <= b /\ b <= f(a) /\ f(a) <= 1 ==> a + b <= 1 \/ b + f(b) <= 1 \/ f(f(b)) <= f(a)");;

// pg. 447
// ------------------------------------------------------------------------- //
// Confirmation of non-convexity.                                            //
// ------------------------------------------------------------------------- //

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
List.map (real_qelim >>|> generalize)
    [(parse "x * y = 0 /\ z = 0 ==> x = z \/ y = z");
    (parse "x * y = 0 /\ z = 0 ==> x = z");
    (parse "x * y = 0 /\ z = 0 ==> y = z")];;

// val it :
//   Reasoning.Automated.Harrison.Handbook.formulas.formula<fol> list =
//   [True; False; False]
List.map (integer_qelim >>|> generalize)
    [(parse "0 <= x /\ x < 2 /\ y = 0 /\ z = 1 ==> x = y \/ x = z");
    (parse "0 <= x /\ x < 2 /\ y = 0 /\ z = 1 ==> x = y");
    (parse "0 <= x /\ x < 2 /\ y = 0 /\ z = 1 ==> x = z")];;

// pg. 449
// ------------------------------------------------------------------------- //
// Failures of original Shostak procedure.                                   //
// ------------------------------------------------------------------------- //

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop (add_default [int_lang]) (parse "f(v - 1) - 1 = v + 1 /\ f(u) + 1 = u - 1 /\ u + 1 = v ==> false");;

// ** And this one is where the original procedure loops **//

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
nelop (add_default [int_lang]) (parse "f(v) = v /\ f(u) = u - 1 /\ u = v ==> false");;

// ------------------------------------------------------------------------- //
// Additional examples not in the text.                                      //
// ------------------------------------------------------------------------- //

//** This is on p. 8 of Shostak's "Deciding combinations" paper

// System.Collections.Generic.KeyNotFoundException: Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
// TODO: Fix bug causing KeyNotFoundException
time (nelop (add_default [int_lang])) (parse "z = f(x - y) /\ x = z + y /\ ~(-(y) = -(x - f(f(z)))) ==> false");;

//** This (ICS theories-1) fails without array operations

time (nelop (add_default [int_lang])) (parse "a + 2 = b ==> f(read(update(A,a,3),b-2)) = f(b - a + 1)");;

//** can-001 from ICS examples site, with if-then-elses expanded manually

time (nelop (add_default [int_lang])) (parse "(x = y /\ z = 1 ==> f(f((x+z))) = f(f((1+y))))");;

// ** RJB example; lists plus uninterpreted functions

time (nelop (add_default [int_lang])) (parse "hd(x) = hd(y) /\ tl(x) = tl(y) /\ ~(x = nil) /\ ~(y = nil) ==> f(x) = f(y)");;

// ** Another one from the ICS paper

time (nelop (add_default [int_lang])) (parse "~(f(f(x) - f(y)) = f(z)) /\ y <= x /\ y >= x + z /\ z >= 0 ==> false");;

// ** Shostak's "A Practical Decision Procedure..." paper
// *** No longer works since I didn't do predicates in congruence closure

time (nelop (add_default [int_lang])) (parse "x < f(y) + 1 /\ f(y) <= x ==> (P(x,y) <=> P(f(y),y))");;

//** Shostak's "Practical..." paper again, using extra clauses for MAX

time (nelop (add_default [int_lang])) (parse "(x >= y ==> MAX(x,y) = x) /\ (y >= x ==> MAX(x,y) = y) ==> x = y + 2 ==> MAX(x,y) = x");;

// ** Shostak's "Practical..." paper again

time (nelop (add_default [int_lang])) (parse "x <= g(x) /\ x >= g(x) ==> x = g(g(g(g(x))))");;

// ** Easy example I invented **//

time (nelop (add_default [real_lang])) (parse "x^2 =  1 ==> (f(x) = f(-(x)))  ==> (f(x) = f(1))");;

// ** Taken from Clark Barrett's CVC page

time (nelop (add_default [int_lang])) (parse "2 * f(x + y) = 3 * y /\ 2 * x = y ==> f(f(x + y)) = 3 * x");;

// ** My former running example in the text; seems too slow.
// *** Anyway this also needs extra predicates in CC

time (nelop (add_default [real_lang])) (parse "x^2 = y^2 /\ x < y /\ z^2 = z /\ x < x * z /\ P(f(1 + z)) ==> P(f(x + y) - f(0))");;

// ** An example where the "naive" procedure is slow but feasible

nelop (add_default [int_lang]) (parse "4 * x = 2 * x + 2 * y /\ x = f(2 * x - y) /\ f(2 * y - x) = 3 /\ f(x) = 4 ==> false");;