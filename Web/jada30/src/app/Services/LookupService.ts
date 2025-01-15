//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class LookupService {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ?? "";
    }

    /**
     * @return OK
     */
    getAllCategory(): Observable<LookupListBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/GetAllCategory";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAllCategory(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAllCategory(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupListBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupListBaseResponse>;
        }));
    }

    protected processGetAllCategory(response: HttpResponseBase): Observable<LookupListBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupListBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @return OK
     */
    getAll(): Observable<LookupListBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/GetAll";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupListBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupListBaseResponse>;
        }));
    }

    protected processGetAll(response: HttpResponseBase): Observable<LookupListBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupListBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @return OK
     */
    getAll2(refCode: string): Observable<LookupListBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/GetAll/{refCode}";
        if (refCode === undefined || refCode === null)
            throw new Error("The parameter 'refCode' must be defined.");
        url_ = url_.replace("{refCode}", encodeURIComponent("" + refCode));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll2(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll2(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupListBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupListBaseResponse>;
        }));
    }

    protected processGetAll2(response: HttpResponseBase): Observable<LookupListBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupListBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @return OK
     */
    get(code: string): Observable<LookupBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/Get/{code}";
        if (code === undefined || code === null)
            throw new Error("The parameter 'code' must be defined.");
        url_ = url_.replace("{code}", encodeURIComponent("" + code));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupBaseResponse>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<LookupBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @param body (optional) 
     * @return OK
     */
    createLookup(body: Lookup | undefined): Observable<LookupBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/CreateLookup";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreateLookup(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreateLookup(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupBaseResponse>;
        }));
    }

    protected processCreateLookup(response: HttpResponseBase): Observable<LookupBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @param body (optional) 
     * @return OK
     */
    updateLookup(code: string, body: Lookup | undefined): Observable<LookupBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/UpdateLookup/{code}";
        if (code === undefined || code === null)
            throw new Error("The parameter 'code' must be defined.");
        url_ = url_.replace("{code}", encodeURIComponent("" + code));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdateLookup(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateLookup(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<LookupBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<LookupBaseResponse>;
        }));
    }

    protected processUpdateLookup(response: HttpResponseBase): Observable<LookupBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = LookupBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    /**
     * @return OK
     */
    deleteLookup(code: string): Observable<BooleanBaseResponse> {
        let url_ = this.baseUrl + "/api/Lookup/DeleteLookup/{code}";
        if (code === undefined || code === null)
            throw new Error("The parameter 'code' must be defined.");
        url_ = url_.replace("{code}", encodeURIComponent("" + code));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteLookup(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteLookup(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<BooleanBaseResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<BooleanBaseResponse>;
        }));
    }

    protected processDeleteLookup(response: HttpResponseBase): Observable<BooleanBaseResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BooleanBaseResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export class BooleanBaseResponse implements IBooleanBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: boolean;
    errors?: Errors[] | undefined;
    statusCode?: number;

    constructor(data?: IBooleanBaseResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.isSuccess = _data["isSuccess"];
            this.version = _data["version"];
            this.message = _data["message"];
            this.responseData = _data["responseData"];
            if (Array.isArray(_data["errors"])) {
                this.errors = [] as any;
                for (let item of _data["errors"])
                    this.errors!.push(Errors.fromJS(item));
            }
            this.statusCode = _data["statusCode"];
        }
    }

    static fromJS(data: any): BooleanBaseResponse {
        data = typeof data === 'object' ? data : {};
        let result = new BooleanBaseResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["isSuccess"] = this.isSuccess;
        data["version"] = this.version;
        data["message"] = this.message;
        data["responseData"] = this.responseData;
        if (Array.isArray(this.errors)) {
            data["errors"] = [];
            for (let item of this.errors)
                data["errors"].push(item.toJSON());
        }
        data["statusCode"] = this.statusCode;
        return data;
    }
}

export interface IBooleanBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: boolean;
    errors?: Errors[] | undefined;
    statusCode?: number;
}

export class Errors implements IErrors {
    key?: number;
    value?: string | undefined;

    constructor(data?: IErrors) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.key = _data["key"];
            this.value = _data["value"];
        }
    }

    static fromJS(data: any): Errors {
        data = typeof data === 'object' ? data : {};
        let result = new Errors();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["key"] = this.key;
        data["value"] = this.value;
        return data;
    }
}

export interface IErrors {
    key?: number;
    value?: string | undefined;
}

export class Lookup implements ILookup {
    id?: number;
    name!: string | undefined;
    nameAr!: string | undefined;
    description?: string | undefined;
    descriptionAr?: string | undefined;
    internalCode!: string | undefined;
    internalRef?: string | undefined;
    isActive?: boolean;

    constructor(data?: ILookup) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.nameAr = _data["nameAr"];
            this.description = _data["description"];
            this.descriptionAr = _data["descriptionAr"];
            this.internalCode = _data["internalCode"];
            this.internalRef = _data["internalRef"];
            this.isActive = _data["isActive"];
        }
    }

    static fromJS(data: any): Lookup {
        data = typeof data === 'object' ? data : {};
        let result = new Lookup();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["nameAr"] = this.nameAr;
        data["description"] = this.description;
        data["descriptionAr"] = this.descriptionAr;
        data["internalCode"] = this.internalCode;
        data["internalRef"] = this.internalRef;
        data["isActive"] = this.isActive;
        return data;
    }
}

export interface ILookup {
    id?: number;
    name: string | undefined;
    nameAr: string | undefined;
    description?: string | undefined;
    descriptionAr?: string | undefined;
    internalCode: string | undefined;
    internalRef?: string | undefined;
    isActive?: boolean;
}

export class LookupBaseResponse implements ILookupBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: Lookup;
    errors?: Errors[] | undefined;
    statusCode?: number;

    constructor(data?: ILookupBaseResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.isSuccess = _data["isSuccess"];
            this.version = _data["version"];
            this.message = _data["message"];
            this.responseData = _data["responseData"] ? Lookup.fromJS(_data["responseData"]) : <any>undefined;
            if (Array.isArray(_data["errors"])) {
                this.errors = [] as any;
                for (let item of _data["errors"])
                    this.errors!.push(Errors.fromJS(item));
            }
            this.statusCode = _data["statusCode"];
        }
    }

    static fromJS(data: any): LookupBaseResponse {
        data = typeof data === 'object' ? data : {};
        let result = new LookupBaseResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["isSuccess"] = this.isSuccess;
        data["version"] = this.version;
        data["message"] = this.message;
        data["responseData"] = this.responseData ? this.responseData.toJSON() : <any>undefined;
        if (Array.isArray(this.errors)) {
            data["errors"] = [];
            for (let item of this.errors)
                data["errors"].push(item.toJSON());
        }
        data["statusCode"] = this.statusCode;
        return data;
    }
}

export interface ILookupBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: Lookup;
    errors?: Errors[] | undefined;
    statusCode?: number;
}

export class LookupListBaseResponse implements ILookupListBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: Lookup[] | undefined;
    errors?: Errors[] | undefined;
    statusCode?: number;

    constructor(data?: ILookupListBaseResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.isSuccess = _data["isSuccess"];
            this.version = _data["version"];
            this.message = _data["message"];
            if (Array.isArray(_data["responseData"])) {
                this.responseData = [] as any;
                for (let item of _data["responseData"])
                    this.responseData!.push(Lookup.fromJS(item));
            }
            if (Array.isArray(_data["errors"])) {
                this.errors = [] as any;
                for (let item of _data["errors"])
                    this.errors!.push(Errors.fromJS(item));
            }
            this.statusCode = _data["statusCode"];
        }
    }

    static fromJS(data: any): LookupListBaseResponse {
        data = typeof data === 'object' ? data : {};
        let result = new LookupListBaseResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["isSuccess"] = this.isSuccess;
        data["version"] = this.version;
        data["message"] = this.message;
        if (Array.isArray(this.responseData)) {
            data["responseData"] = [];
            for (let item of this.responseData)
                data["responseData"].push(item.toJSON());
        }
        if (Array.isArray(this.errors)) {
            data["errors"] = [];
            for (let item of this.errors)
                data["errors"].push(item.toJSON());
        }
        data["statusCode"] = this.statusCode;
        return data;
    }
}

export interface ILookupListBaseResponse {
    isSuccess?: boolean;
    version?: number;
    message?: string | undefined;
    responseData?: Lookup[] | undefined;
    errors?: Errors[] | undefined;
    statusCode?: number;
}

export class ApiException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}