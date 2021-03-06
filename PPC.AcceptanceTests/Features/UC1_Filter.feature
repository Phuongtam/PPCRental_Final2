﻿@automated
Feature: UC1_Filter
	In order to search project
	As a user of the website
	I want to search project

Background: 
	Given the following project
	| PropertyName                                 | Avarta                                  | Images                                                          | PropertyType | Content                                                                                                                                                                                                                             | Street         | Ward        | District  | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | Agency  | Create_at  | Create_post | Status     | Note | Update_at  | Sale    |
	| PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                 | PIS_7319-Edit-stamp.jpg,                                        | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops.                                                                                                                                             | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 10000  | VND       | 120m2 | 3       | 2        | 1            | Ly Chau | 2017-11-09 | 2017-11-09  | Đã duyệt   | Done | 2017-11-23 | Ly Chau |
	| ViLa Q7                                      | sunshine-benthanh-cityhome-10-stamp.jpg | PIS_7319-Edit-stamp.jpg,                                        | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.                                                                                                                          | Số 39          | TT Xuân Mai | Chương Mỹ | 70000  | VND       | 120m2 | 3       | 4        | 1            | son     | 2017-11-09 | 2017-11-09  | Đã duyệt   | Done | 2017-11-23 | Ly Chau |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp.jpg | PIS_7389-Edit-stamp.jpg,sunshine-benthanh-cityhome-10-stamp.jpg | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..                                                                                                                                 | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 30000  | VND       | 130m2 | 2       | 3        | 1            | son     | 2017-11-09 | 2017-11-09  | Đã duyệt   | Done | 2017-11-23 | Ly Chau |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                 | PIS_7319-Edit-stamp.jpg,                                        | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer.                                                                                                                        | Số 39          | TT Xuân Mai | Chương Mỹ | 110000 | VND       | 150m2 | 4       | 2        | 1            | Ly Chau | 2017-11-09 | 2017-11-09  | Đã duyệt   | Done | 2017-11-23 | Ly Chau |
	| Saigon Pearl Ruby Block                      | PIS_7319-Edit-stamp.jpg                 | PIS_7319-Edit-stamp.jpg,                                        | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…                                                                                                                                   | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 30000  | VND       | 130m2 | 3       | 5        | 1            | Ly Chau | 2017-11-09 | 2017-11-09  | Đã duyệt   | Done | 2017-11-23 | Ly Chau |
	| ICON 56 – Modern Style Apartment             | PIS_7432-Edit-stamp.jpg                 | PIS_7432-Edit-stamp.jpg,                                        | Villa        | ICON 56 – Modern Style Apartment $ 950 Per Month Condominium in Rentals 56 Ben Van Don, Ho Chi Minh City Icon 56 is 4 star building with strategic location and excellent amenities including infinity swimming pool and modern gym | Quảng Phúc     | Ba Trại     | Ba Vì     | 30000  | VND       | 130m2 | 2       | 3        | 1            | son     | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 |   Ly Chau  |

	Given user table :
	| Email                    | Password | FullName | Phone      | Address       | Role | Status |
	| lythihuyenchau@gmail.com | 123456   | Ly Chau | 0999580654 | Trần Hưng Đạo | 1    | True   |
	| sonnguyen@gmail.com      | 123456   | son      | 09999999   | Trần Hưng Đạo | 2    | True   |
Scenario: search project
	When I search for projects by the phrase 'PIS','Apartment','Chương Mỹ'
	Then project should display project with projectname follow 'PIS Top Apartment'
	
	

