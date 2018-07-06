Feature: Login
	In order to 避免非法使用者使用系統
	As a 系統管理者
	I want to be 檢查帳號密碼是否合法

@mytag
Scenario: 登入失敗，顯示錯訊息
	Given Login 的頁面
	And 在帳號輸入"joe"
	And 在密碼輸入"11"
	When 按下登入
	Then 顯示"帳號或密碼有誤"
