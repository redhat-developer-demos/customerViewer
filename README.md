# customerViewer
Blazor frontend for customer viewing activity

## Part of the Red Hat Developer learning path entitled "Using Red Hat OpenShift labels"##

`oc new-app https://github.com/donschenck/customerviewer --labels=app.kubernetes.io/part-of=customers,systemname=customers,tier=frontend,language=blazor,customers=frontend --image-stream="openshift/dotnet:6.0-ubi8"`


`oc expose service/customerviewer`


`oc set env deploy/customerviewer TRIVIAHHH_GATEWAY_URL=http://triviahhh-api-gateway:8080/gateway/customers`

