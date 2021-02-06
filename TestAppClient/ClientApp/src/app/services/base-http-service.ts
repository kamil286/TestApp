import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ServiceResponseModel } from '../models';

export abstract class BaseHttpService {
	protected static readonly ServiceUrl: string = 'api/';
	private cache: CacheValue[] = [];

	constructor(protected readonly http: HttpClient) {}

	protected async httpGet<TResponse>(
		endpoint: string,
		params?: any
	): Promise<TResponse> {
		const httpParams = this.getRequestParams(params);
		const response = await this.http
			.get<TResponse>(`${this.serviceUrl}${endpoint}`, {
			headers: this.getRequestHeaders(),
			params: httpParams,
			})
			.toPromise<TResponse>();

		return response;
	}

	protected async httpPost<TResponse, TBody>(
		endpoint: string,
		object: TBody,
		params?: any
	): Promise<TResponse> {
		const httpParams = this.getRequestParams(params);

		const response = await this.http
			.post<TResponse>(`${this.serviceUrl}${endpoint}`, object, {
                headers: this.getRequestHeaders(),
                params: httpParams,
			})
			.toPromise<TResponse>();

		return response;
	}

	protected async httpPut<TResponse, TBody>(
		endpoint: string,
		object: TBody,
		params?: any
	) {
		const httpParams = this.getRequestParams(params);

		const response = await this.http
			.put<TResponse>(`${this.serviceUrl}${endpoint}`, object, {
                headers: this.getRequestHeaders(),
                params: httpParams,
			})
			.toPromise<TResponse>();

		return response;
	}

	protected async httpDelete<TResponse>(
		endpoint: string,
		params?: any
	): Promise<TResponse> {
		const httpParams = this.getRequestParams(params);
		const response = await this.http
			.delete<TResponse>(
                `${this.serviceUrl}${endpoint}`,
                {
                    headers: this.getRequestHeaders(),
                    params: httpParams,
                }
			)
			.toPromise<TResponse>();

		return response;
	}

	protected get serviceUrl(): string {
		return BaseHttpService.ServiceUrl;
	}

	protected getRequestParams(params: any): HttpParams {
		if (params == null) { return null; }

		let httpParams = new HttpParams();
		Object.keys(params).forEach((key) => {
			if (params[key] != null) {
			httpParams = httpParams.append(key, params[key]);
			}
		});
		return httpParams;
	}

	protected getRequestHeaders(): HttpHeaders {
		const headers = new HttpHeaders({
			'Content-Type': 'application/json; charset=utf-8',
			'Cache-Control': 'no-cache, max-age=0',
			Pragma: 'no-cache',
		});
		return headers;
	}

	protected addParam(
		filters: any,
		paramName: string,
		paramValue: any,
		ignoreNoneValue: boolean
	): any {
		if (paramValue == null) {
			return filters;
		}

		if (ignoreNoneValue && paramValue === -1) {
			return filters;
		}

		filters[paramName] = paramValue;
		return filters;
	}

	protected async getCached(cacheKey: string, cachedFn: () => Promise<any>): Promise<any> {
		let cacheEntry = this.cache.find(c => c.key == cacheKey);
		if (cacheEntry == null) {
			let promise = cachedFn();
			let newCacheEntry: CacheValue = {
				key: cacheKey,
				promise: promise,
			};
			this.cache.push(newCacheEntry);
			return await promise;
		}

		return await cacheEntry.promise;
	}
}

class CacheValue {
	public key: string;
	public promise?: Promise<any>;
}
