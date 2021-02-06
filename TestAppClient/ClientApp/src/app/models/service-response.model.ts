export abstract class ServiceResponseModel<T> {
    public Data: T;
    public isError: boolean;
    public errorMessage: string;
    public stackTrace: string;
    public exception: string;
}