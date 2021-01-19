# WPF-Bezier-Interpolation
========================

This is a sample project for the CodeProject article <a href="http://www.codeproject.com/Articles/769055/Interpolate-2D-points-usign-Bezier-curves-in-WPF">Interpolate 2D points, usign Bezier curves in WPF<a/>. I suggest to read the article.

![Alt text](screenshot.jpg?raw=true "The sample running")

## What is it about?
-----------------

The main goal of this project is provide a control that, given a sorted collection of points draw a curve for interpolate those points (the curve will pass for each point). 

Besides that, another goal is that this control could be used along the MVVM pattern, then when each point's position changes, or when any point is added or removed, the control is refreshed.

In this example app, the points can be dragged by the user, and also can be draw a closed or open curve.

## UPDATE 1.0: 
-------------------
Also was added the adding points in the best curve placement behavior. Now when clicking in some canvas locations, a point is added to the curve and inserted at the right point.

## UPDATE 2.0: 
-------------------
The math related to the interpolation has been refactored to a new .Nuget package. In this way becomes more ease to use it in other projects. This packages is [Rulyotano.Math](https://www.nuget.org/packages/Rulyotano.Math/) and the code can be found at [Github Project](https://github.com/rulyotano/Rulyotano.Math).

## Want to contribute?
-------------------
You are welcome!
