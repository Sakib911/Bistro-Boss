var app = angular.module("my-app",[]);
    app.factory('interceptor',[function(){
			var interceptor = {
				request:function(config){
					config.headers.Authorization = localStorage.getItem("tkey");
					return config;
				},
				response:function(response){
					return response;
				}
			};
			return interceptor;
		}]);
		
		app.config(function($httpProvider){
			$httpProvider.interceptors.push('interceptor');
		});
		app.controller('AdminCtrl',function($scope,$http){
			$http.get("https://localhost:44373/api/admins/"+localStorage.getItem("user")).then(function(resp){
			debugger;
				$scope.admin = resp.data;
			},
			function(err){
			debugger;
			});
		});


		app.controller('AdminEditCtrl',function($scope,$http){
			$http.Post("https://localhost:44373/api/admins/{username}/update"+localStorage.PostItem("user"))+localStorage.postItem("admins").then(function(resp){
			debugger;
				$scope.admin = resp.data;
			},
			function(err){
			debugger;
			});
		});

      app.controller('logoutCtrl',function($scope,$http){
			$scope.load=function(){
				//alert("OK");
				$http.post("https://localhost:44373/api/logout").then(function(resp){
					window.location.href = "../../login.html"
				},function(err){
					$scope.msg = err.data.Msg;
				});
			};
			
		});