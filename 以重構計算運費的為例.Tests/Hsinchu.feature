﻿Feature: Hsinchu
	In order to 供帳務拆帳使用
	As a PM
	I want to be 根據商品資訊算出運費

@mytag
Scenario: 新竹貨運計算運費
	Given 商品規格為
	| Length | Width | Height | Weight | Name                      |
	| 30     | 20    | 10     | 10     | ASP.NET MVC 4 網站開發美學 |
	When 呼叫計算運費
	Then 運費結果應為 254.16