var vm = new Vue({
    el: '#app',
    data: {
        message: 'Hello'
        , user_read_data: {
            body: [{
                id: '' //Guid
                , user_name: '' //string
                , name_first: '' //string
                , name_last: '' //string
                , email_address: '' //string
                , user_status: 0 //int
                , record_created: '' //DateTime
                , record_updated: '' //DateTime
                , record_status: 0 //int = 0;
            }]
            , meta: {
                called: ''
                , code: 0
                , endpoint: ''
                , message: ''
            }
        }
    }
    , mounted: function () {
        var _function = 'mounted(): ';
        console.log(_function + 'Preparing page...');
        this.user_read_data = { body: [], head: {} };
        this.$nextTick(function () {
            
            this.user_read_call();
        });
    }
    , methods: {
        initialize_page: function () {
            var _function = 'initialize_page(): ';
            vm.user_read_call();
            console.log(_function + 'Page Ready.');
        }
        , user_read_call: function () {
            var _function = 'user_read_call(): ';
            var _service = '/userapi/user_search';
            var _params = {
                user_guid: "58AA63CE-40E9-40C2-B3C2-852DC6AC7722"
            };
            axios.post(
                _service
                , _params
            ).then(function (response) {
                console.log(_function + 'Got Response.');
                console.log(response);
                vm.user_read_data = response.data;
                console.log(_function+'Done.');
            })
            .catch(function (error) {
                console.log(error);
            });
        }
    }
})
console.log('index.js loaded');